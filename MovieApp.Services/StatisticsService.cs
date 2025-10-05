using Microsoft.EntityFrameworkCore;
using MovieApp.DataContext;
using MovieApp.DataContext.Context;
using MovieApp.DataContext.Dtos;

namespace MovieApp.Services
{
    public interface IStatisticsService
    {
        Task<List<MovieDto>> GetMostViewedMoviesAsync(int topN = 5);
        Task<List<MovieDto>> GetTopRatedMoviesAsync(int topN = 5);
        Task<List<MovieDto>> GetMostFavoritedMoviesAsync(int topN = 5);
        Task<List<UserStatisticsDto>> GetMostActiveUsersAsync(int topN = 5);
    }

    public class StatisticsService : IStatisticsService
    {
        private readonly MovieAppDbContext _context;

        public StatisticsService(MovieAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieDto>> GetMostViewedMoviesAsync(int topN = 5)
        {
            return await _context.Movies
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .OrderByDescending(m => m.ViewHistory.Count)
                .Take(topN)
                .Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ReleaseYear = m.ReleaseYear,
                    PosterUrl = m.PosterUrl,
                    AverageRating = m.AverageRating,
                    Genres = m.MovieGenres.Select(g => g.Genre.Name).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<MovieDto>> GetTopRatedMoviesAsync(int topN = 5)
        {
            return await _context.Movies
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .OrderByDescending(m => m.AverageRating)
                .ThenByDescending(m => m.Ratings.Count)
                .Take(topN)
                .Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ReleaseYear = m.ReleaseYear,
                    PosterUrl = m.PosterUrl,
                    AverageRating = m.AverageRating,
                    Genres = m.MovieGenres.Select(g => g.Genre.Name).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<MovieDto>> GetMostFavoritedMoviesAsync(int topN = 5)
        {
            return await _context.Movies
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .OrderByDescending(m => m.Favorites.Count)
                .Take(topN)
                .Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ReleaseYear = m.ReleaseYear,
                    PosterUrl = m.PosterUrl,
                    AverageRating = m.AverageRating,
                    Genres = m.MovieGenres.Select(g => g.Genre.Name).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<UserStatisticsDto>> GetMostActiveUsersAsync(int topN = 5)
        {
            return await _context.Users
                .OrderByDescending(u => u.ViewHistory.Count + u.Ratings.Count + u.Favorites.Count)
                .Take(topN)
                .Select(u => new UserStatisticsDto
                {
                    UserId = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    TotalViews = u.ViewHistory.Count,
                    TotalRatings = u.Ratings.Count,
                    TotalFavorites = u.Favorites.Count
                })
                .ToListAsync();
        }
    }
}
