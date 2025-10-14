using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.DataContext.Context;
using MovieApp.DataContext.Dtos;
using MovieApp.DataContext.Entities;

public interface IRatingService
{
    Task<IEnumerable<RatingDto>> GetRatingsForMovieAsync(int movieId);
    Task<IEnumerable<RatingDto>> GetRatingsByUserAsync(int userId);
    Task<RatingDto> AddOrUpdateRatingAsync(int userId, CreateRatingDto dto);
    Task<MovieRatingSummaryDto> GetMovieRatingSummaryAsync(int movieId);
}

public class RatingService : IRatingService
{
    private readonly MovieAppDbContext _context;
    private readonly IMapper _mapper;

    public RatingService(MovieAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RatingDto>> GetRatingsForMovieAsync(int movieId)
    {
        var ratings = await _context.Ratings
            .Where(r => r.MovieId == movieId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<RatingDto>>(ratings);
    }

    public async Task<IEnumerable<RatingDto>> GetRatingsByUserAsync(int userId)
    {
        var ratings = await _context.Ratings
            .Where(r => r.UserId == userId)
            .Include(r => r.Movie)
            .ToListAsync();

        return _mapper.Map<IEnumerable<RatingDto>>(ratings);
    }

    public async Task<RatingDto> AddOrUpdateRatingAsync(int userId, CreateRatingDto dto)
    {
        var existing = await _context.Ratings
            .FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId == dto.MovieId);

        if (existing != null)
        {
            existing.Score = dto.Score;
            existing.CreatedAt = DateTime.UtcNow;
        }
        else
        {
            var rating = _mapper.Map<Rating>(dto);
            rating.UserId = userId;
            _context.Ratings.Add(rating);
        }

        await _context.SaveChangesAsync();
        await UpdateAverageRating(dto.MovieId);
        var saved = await _context.Ratings
            .FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId == dto.MovieId);

        return _mapper.Map<RatingDto>(saved!);
    }

    private async Task UpdateAverageRating(int movieId)
    {
        var movie = await _context.Movies
            .Include(m => m.Ratings)
            .FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null) return;

        movie.AverageRating = movie.Ratings.Any()
            ? movie.Ratings.Average(r => r.Score)
            : 0;

        await _context.SaveChangesAsync();
    }

    public async Task<MovieRatingSummaryDto> GetMovieRatingSummaryAsync(int movieId)
    {
        var query = _context.Ratings.Where(r => r.MovieId == movieId);
        var count = await query.CountAsync();
        var avg = count > 0 ? await query.AverageAsync(r => r.Score) : 0.0;
        return new MovieRatingSummaryDto
        {
            MovieId = movieId,
            AverageRating = Math.Round(avg, 2),
            RatingCount = count
        };
    }
}
