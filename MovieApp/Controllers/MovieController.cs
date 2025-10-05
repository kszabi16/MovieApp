using Microsoft.AspNetCore.Mvc;
using MovieApp.DataContext.Dtos;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
    {
        var movies = await _movieService.GetAllAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetById(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);
        if (movie == null)
            return NotFound();

        return Ok(movie);
    }

    [HttpPost("create")]
    public async Task<ActionResult<MovieDto>> Create([FromBody] MovieCreateDto dto)
    {
        var created = await _movieService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MovieDto>> Update(int id, [FromBody] MovieCreateDto dto)
    {
        var updated = await _movieService.UpdateAsync(id, dto);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _movieService.DeleteAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}
