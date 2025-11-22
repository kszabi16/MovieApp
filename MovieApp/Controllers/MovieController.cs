using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DataContext.Dtos;
using MovieApp.Services;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;
    private readonly IRatingService _ratingService;
    private readonly IStatisticsService _statisticsService;

    public MovieController(IMovieService movieService, IRatingService ratingService, IStatisticsService statisticsService)
    {
        _movieService = movieService;
        _ratingService = ratingService;
        _statisticsService = statisticsService;
    }

    [AllowAnonymous]
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
    {
        var movies = await _movieService.GetAllAsync();
        return Ok(movies);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetById(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);
        if (movie == null)
            return NotFound();

        return Ok(movie);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<MovieDto>> Create([FromBody] MovieCreateDto dto)
    {
        var created = await _movieService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<MovieDto>> Update(int id, [FromBody] MovieCreateDto dto)
    {
        var updated = await _movieService.UpdateAsync(id, dto);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _movieService.DeleteAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> Get([FromQuery] string? genre)
    {
        if (!string.IsNullOrWhiteSpace(genre))
        {
            var byGenre = await _movieService.GetByGenreAsync(genre);
            return Ok(byGenre);
        }

        var movies = await _movieService.GetAllAsync();
        return Ok(movies);
    }

    [AllowAnonymous]
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<MovieDto>>> Search([FromQuery] string? query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("A keresőkifejezés (query) kötelező.");

        var results = await _movieService.SearchAsync(query);
        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("latest")]
    public async Task<ActionResult<IEnumerable<MovieDto>>> Latest([FromQuery] int count = 10)
    {
        if (count <= 0) count = 10;
        var results = await _movieService.GetLatestAsync(count);
        return Ok(results);
    }

    
    [AllowAnonymous]
    [HttpGet("{id}/rating")]
    public async Task<ActionResult<MovieRatingSummaryDto>> GetRatingSummary(int id)
    {
        var summary = await _ratingService.GetMovieRatingSummaryAsync(id);
        return Ok(summary);
    }


    [AllowAnonymous]
    [HttpGet("{id}/stats")]
    public async Task<ActionResult<MovieEngagementStatsDto>> MovieStats(int id)
    {
        var stats = await _statisticsService.GetMovieEngagementAsync(id);
        if (stats == null) return NotFound();
        return Ok(stats);
    }
}
