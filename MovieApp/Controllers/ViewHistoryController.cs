using Microsoft.AspNetCore.Mvc;
using MovieApp.DataContext.Dtos;

[ApiController]
[Route("api/[controller]")]
public class ViewHistoryController : ControllerBase
{
    private readonly IViewHistoryService _viewHistoryService;

    public ViewHistoryController(IViewHistoryService viewHistoryService)
    {
        _viewHistoryService = viewHistoryService;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<ViewHistoryDto>>> GetUserHistory(int userId)
    {
        var history = await _viewHistoryService.GetUserHistoryAsync(userId);
        return Ok(history);
    }

    [HttpPost("{userId}/{movieId}")]
    public async Task<ActionResult<ViewHistoryDto>> AddView(int userId, int movieId)
    {
        var result = await _viewHistoryService.AddViewAsync(userId, movieId);
        return Ok(result);
    }
}
