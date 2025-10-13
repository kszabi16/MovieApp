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
                    UserId = (uint)r.UserId,   // uint típust használjunk
                    MovieId = (uint)r.MovieId,
                    Score = (float)r.Score
                })
                .ToListAsync();

            if (!ratings.Any())
                return new List<MovieDto>();

            // Adatok betöltése ML.NET-be
            var dataView = _mlContext.Data.LoadFromEnumerable(ratings);

            // Pipeline: kulcs-konverzió + tanító algoritmus
            var pipeline = _mlContext.Transforms.Conversion
                .MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: nameof(MovieRatingData.UserId))
                .Append(_mlContext.Transforms.Conversion
                    .MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: nameof(MovieRatingData.MovieId)))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                    new Microsoft.ML.Trainers.MatrixFactorizationTrainer.Options
                    {
                        MatrixColumnIndexColumnName = "userIdEncoded",
                        MatrixRowIndexColumnName = "movieIdEncoded",
                        LabelColumnName = nameof(MovieRatingData.Score),
                        NumberOfIterations = 40,
                        ApproximationRank = 100
                    }));

            // Modell tanítása
            var model = pipeline.Fit(dataView);

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

            // PredictionEngine létrehozása
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<MovieRatingData, MovieRatingPrediction>(model);

            var predictions = new List<(Movie movie, float score)>();

            foreach (var movie in allMovies)
            {
                if (seenMovieIds.Contains(movie.Id))
                    continue;

                var prediction = predictionEngine.Predict(new MovieRatingData
                {
                    UserId = (uint)userId,
                    MovieId = (uint)movie.Id
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
            [LoadColumn(0)] public uint UserId { get; set; }   // uint, nem float
            [LoadColumn(1)] public uint MovieId { get; set; }
            [LoadColumn(2)] public float Score { get; set; }
        }

        private class MovieRatingPrediction
        {
            public float Score { get; set; }
        }
    }
}
