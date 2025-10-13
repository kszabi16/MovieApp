using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.DataContext.Context;
using MovieApp.DataContext.Dtos;
using MovieApp.DataContext.Entities;

public interface IFavoriteService
{
    Task<IEnumerable<FavoriteDto>> GetFavoritesByUserAsync(int userId);
    Task<FavoriteDto?> AddFavoriteAsync(int userId, AddFavoriteDto dto);
    Task<bool> RemoveFavoriteAsync(int userId, int movieId);
}

public class FavoriteService : IFavoriteService
{
    private readonly MovieAppDbContext _context;
    private readonly IMapper _mapper;

    public FavoriteService(MovieAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FavoriteDto>> GetFavoritesByUserAsync(int userId)
    {
        var favorites = await _context.Favorites
            .Include(f => f.Movie)
            .Where(f => f.UserId == userId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<FavoriteDto>>(favorites);
    }

    public async Task<FavoriteDto?> AddFavoriteAsync(int userId, AddFavoriteDto dto)
    {
        var exists = await _context.Favorites
            .AnyAsync(f => f.UserId == userId && f.MovieId == dto.MovieId);

        if (exists)
            return null; 

        var favorite = _mapper.Map<Favorite >(dto);
        favorite.UserId = userId;

        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();

        await _context.Entry(favorite).Reference(f => f.Movie).LoadAsync();

        return _mapper.Map<FavoriteDto>(favorite);
    }

    public async Task<bool> RemoveFavoriteAsync(int userId, int movieId)
    {
        var favorite = await _context.Favorites
            .FirstOrDefaultAsync(f => f.UserId == userId && f.MovieId == movieId);

        if (favorite == null)
            return false;

        _context.Favorites.Remove(favorite);
        await _context.SaveChangesAsync();
        return true;
    }
}
