using Microsoft.AspNetCore.Mvc;
using MovieApp.DataContext.Dtos;

[ApiController]
[Route("api/[controller]")]
public class RatingController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpGet("movie/{movieId}")]
    public async Task<ActionResult<IEnumerable<RatingDto>>> GetByMovie(int movieId)
    {
        var ratings = await _ratingService.GetRatingsForMovieAsync(movieId);
        return Ok(ratings);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<RatingDto>>> GetByUser(int userId)
    {
        var ratings = await _ratingService.GetRatingsByUserAsync(userId);
        return Ok(ratings);
    }

    [HttpPost("{userId}")]
    public async Task<ActionResult<RatingDto>> AddOrUpdate(int userId, [FromBody] CreateRatingDto dto)
    {
        if (dto.Score < 1 || dto.Score > 10)
            return BadRequest("A pontszámnak 1 és 10 között kell lennie.");

        var rating = await _ratingService.AddOrUpdateRatingAsync(userId, dto);
        return Ok(rating);
    }
}
