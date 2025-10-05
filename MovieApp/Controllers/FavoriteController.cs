using Microsoft.AspNetCore.Mvc;
using MovieApp.DataContext.Dtos;

[ApiController]
[Route("api/[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteService _favoriteService;

    public FavoriteController(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<FavoriteDto>>> GetByUser(int userId)
    {
        var favorites = await _favoriteService.GetFavoritesByUserAsync(userId);
        return Ok(favorites);
    }

    [HttpPost("{userId}")]
    public async Task<ActionResult<FavoriteDto>> AddFavorite(int userId, [FromBody] AddFavoriteDto dto)
    {
        var result = await _favoriteService.AddFavoriteAsync(userId, dto);
        if (result == null)
            return BadRequest("A film már szerepel a kedvencek között.");

        return Ok(result);
    }

    [HttpDelete("{userId}/{movieId}")]
    public async Task<IActionResult> RemoveFavorite(int userId, int movieId)
    {
        var success = await _favoriteService.RemoveFavoriteAsync(userId, movieId);
        if (!success)
            return NotFound("A megadott kedvenc nem található.");

        return NoContent();
    }
}
