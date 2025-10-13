using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using MovieApp.DataContext.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace MovieApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationService _recommendationService;

        public RecommendationController(RecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<MovieDto>>> GetRecommendations(int userId, [FromQuery] int count = 5)
        {
            try
            {
                var recommendations = await _recommendationService.GetRecommendationsForUserAsync(userId, count);

                if (recommendations == null || !recommendations.Any())
                    return NotFound("Nem található ajánlás ehhez a felhasználóhoz.");

                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt az ajánlások generálása közben: {ex.Message}");
            }
        }
    }
}
