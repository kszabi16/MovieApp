using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.DataContext.Context;
using MovieApp.DataContext.Dtos;
using MovieApp.DataContext.Entities;

public interface IViewHistoryService
{
    Task<IEnumerable<ViewHistoryDto>> GetUserHistoryAsync(int userId);
    Task<ViewHistoryDto> AddViewAsync(int userId, int movieId);
}

public class ViewHistoryService : IViewHistoryService
{
    private readonly MovieAppDbContext _context;
    private readonly IMapper _mapper;

    public ViewHistoryService(MovieAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ViewHistoryDto>> GetUserHistoryAsync(int userId)
    {
        var history = await _context.ViewHistory
            .Include(v => v.Movie)
            .Where(v => v.UserId == userId)
            .OrderByDescending(v => v.ViewedAt)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ViewHistoryDto>>(history);
    }

    public async Task<ViewHistoryDto> AddViewAsync(int userId, int movieId)
    {
        var view = new ViewHistory
        {
            UserId = userId,
            MovieId = movieId,
            ViewedAt = DateTime.UtcNow
        };

        _context.ViewHistory.Add(view);
        await _context.SaveChangesAsync();

        await _context.Entry(view).Reference(f => f.Movie).LoadAsync();

        return _mapper.Map<ViewHistoryDto>(view);
    }
}
