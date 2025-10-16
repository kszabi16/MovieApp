using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.DataContext.Context;
using MovieApp.DataContext.Dtos;
using MovieApp.DataContext.Entities;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetAllAsync();
    Task<MovieDto?> GetByIdAsync(int id);
    Task<MovieDto> CreateAsync(MovieCreateDto dto);
    Task<MovieDto?> UpdateAsync(int id, MovieCreateDto dto);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<MovieDto>> GetByGenreAsync(string genre);
    Task<IEnumerable<MovieDto>> SearchAsync(string query);
    Task<IEnumerable<MovieDto>> GetLatestAsync(int count);
}

public class MovieService : IMovieService
{
    private readonly MovieAppDbContext _context;
    private readonly IMapper _mapper;

    public MovieService(MovieAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        var movies = await _context.Movies
            .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
            .Include(m => m.Ratings)
            .ToListAsync();
        foreach (var movie in movies)
        {
            movie.AverageRating = movie.Ratings.Any()
                ? movie.Ratings.Average(r => r.Score)
                : 0;
        }

        await _context.SaveChangesAsync();

        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task<MovieDto?> GetByIdAsync(int id)
    {
        var movie = await _context.Movies
            .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
            .Include(m => m.Ratings)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
            return null;

        movie.AverageRating = movie.Ratings.Any()
            ? movie.Ratings.Average(r => r.Score)
            : 0;

        await _context.SaveChangesAsync();

        return _mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto> CreateAsync(MovieCreateDto dto)
    {
        var movie = _mapper.Map<Movie>(dto);

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        await _context.Entry(movie)
            .Collection(m => m.MovieGenres)
            .Query()
            .Include(mg => mg.Genre)
            .LoadAsync();

        return _mapper.Map<MovieDto>(movie);
    }

    public async Task<MovieDto?> UpdateAsync(int id, MovieCreateDto dto)
    {
        var movie = await _context.Movies
            .Include(m => m.MovieGenres)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
            return null;

        movie.Title = dto.Title;
        movie.Description = dto.Description;
        movie.ReleaseYear = dto.ReleaseYear;
        movie.PosterUrl = dto.PosterUrl;
        _context.MovieGenres.RemoveRange(movie.MovieGenres);
        movie.Director = dto.Director;
        movie.MovieGenres = dto.GenreIds.Select(id => new MovieGenre
        {
            MovieId = movie.Id,
            GenreId = id
        }).ToList();

        await _context.SaveChangesAsync();
        await _context.Entry(movie)
            .Collection(m => m.MovieGenres)
            .Query()
            .Include(mg => mg.Genre)
            .LoadAsync();

        return _mapper.Map<MovieDto>(movie);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
            return false;

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<MovieDto>> GetByGenreAsync(string genre)
    {
        var genreLower = genre.Trim().ToLower();
        var movies = await _context.Movies
            .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
            .Include(m => m.Ratings)
            .Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == genreLower))
            .ToListAsync();

        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task<IEnumerable<MovieDto>> SearchAsync(string query)
    {
        var q = query.Trim();
        var movies = await _context.Movies
            .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
            .Where(m => EF.Functions.Like(m.Title, "%" + q + "%") || EF.Functions.Like(m.Description, "%" + q + "%"))
            .ToListAsync();

        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }


    public async Task<IEnumerable<MovieDto>> GetLatestAsync(int count)
    {
        if (count <= 0) count = 10;

        var movies = await _context.Movies
            .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
            .OrderByDescending(m => m.Id)
            .Take(count)
            .ToListAsync();

        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }
}
