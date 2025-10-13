using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using MovieApp.DataContext.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace MovieApp.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("most-viewed")]
        public async Task<ActionResult<List<MovieDto>>> GetMostViewedMovies([FromQuery] int count = 5)
        {
            var result = await _statisticsService.GetMostViewedMoviesAsync(count);
            return Ok(result);
        }

        [HttpGet("top-rated")]
        public async Task<ActionResult<List<MovieDto>>> GetTopRatedMovies([FromQuery] int count = 5)
        {
            var result = await _statisticsService.GetTopRatedMoviesAsync(count);
            return Ok(result);
        }

        [HttpGet("most-favorited")]
        public async Task<ActionResult<List<MovieDto>>> GetMostFavoritedMovies([FromQuery] int count = 5)
        {
            var result = await _statisticsService.GetMostFavoritedMoviesAsync(count);
            return Ok(result);
        }

        [HttpGet("active-users")]
        public async Task<ActionResult<List<UserStatisticsDto>>> GetMostActiveUsers([FromQuery] int count = 5)
        {
            var result = await _statisticsService.GetMostActiveUsersAsync(count);
            return Ok(result);
        }
    }
}
