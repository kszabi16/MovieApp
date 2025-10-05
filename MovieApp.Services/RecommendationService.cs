using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MovieApp.DataContext.Context;
using MovieApp.DataContext.Dtos;
using MovieApp.DataContext.Entities;

namespace MovieApp.Services
{
    public class RecommendationService
    {
        private readonly MovieAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly MLContext _mlContext;

        public RecommendationService(MovieAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _mlContext = new MLContext();
        }

        public async Task<List<MovieDto>> GetRecommendationsForUserAsync(int userId, int topN = 5)
        {
            // Lekérjük az összes értékelést
            var ratings = await _context.Ratings
                .AsNoTracking()
                .Select(r => new MovieRatingData
                {
                    UserId = (float)r.UserId,
                    MovieId = (float)r.MovieId,
                    Label = (float)r.Score
                })
                .ToListAsync();

            if (!ratings.Any())
                return new List<MovieDto>();

            // Adatok betöltése ML.NET-be
            var trainingData = _mlContext.Data.LoadFromEnumerable(ratings);

            // Modell tanítása (Matrix Factorization)
            var options = new Microsoft.ML.Trainers.MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = nameof(MovieRatingData.UserId),
                MatrixRowIndexColumnName = nameof(MovieRatingData.MovieId),
                LabelColumnName = nameof(MovieRatingData.Label),
                NumberOfIterations = 40,
                ApproximationRank = 100
            };

            var model = _mlContext.Recommendation().Trainers.MatrixFactorization(options).Fit(trainingData);

            // Felhasználó által már látott filmek
            var seenMovieIds = await _context.ViewHistory
                .Where(v => v.UserId == userId)
                .Select(v => v.MovieId)
                .ToListAsync();

            // Összes film az adatbázisból
            var allMovies = await _context.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .AsNoTracking()
                .ToListAsync();

            // Előrejelzések minden filmre
            var predictions = new List<(Movie movie, float score)>();
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<MovieRatingData, MovieRatingPrediction>(model);

            foreach (var movie in allMovies)
            {
                // Már látott filmek kihagyása
                if (seenMovieIds.Contains(movie.Id))
                    continue;

                var prediction = predictionEngine.Predict(new MovieRatingData
                {
                    UserId = userId,
                    MovieId = movie.Id
                });

                predictions.Add((movie, prediction.Score));
            }

            // Legjobb filmek kiválasztása
            var topMovies = predictions
                .OrderByDescending(p => p.score)
                .Take(topN)
                .Select(p => _mapper.Map<MovieDto>(p.movie))
                .ToList();

            return topMovies;
        }

        // ML.NET input/output osztályok
        private class MovieRatingData
        {
            [LoadColumn(0)] public float UserId { get; set; }
            [LoadColumn(1)] public float MovieId { get; set; }
            [LoadColumn(2)] public float Label { get; set; }
        }

        private class MovieRatingPrediction
        {
            public float Score { get; set; }
        }
    }
}
