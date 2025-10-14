using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DataContext.Dtos;
using MovieApp.Services;
using System;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRatingService _ratingService;
        private readonly IFavoriteService _favoriteService;
        private readonly IViewHistoryService _viewHistoryService;
        private readonly RecommendationService _recommendationService;

        public UserController(IUserService userService, IRatingService ratingService, IFavoriteService favoriteService, 
            IViewHistoryService viewHistoryService, RecommendationService recommendationService)
        {
            _userService = userService;
            _ratingService = ratingService;
            _favoriteService = favoriteService;
            _viewHistoryService = viewHistoryService;
            _recommendationService = recommendationService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (id != userDto.Id)
                return BadRequest("User ID mismatch.");

            var updatedUser = await _userService.UpdateUserAsync(id, userDto);
            if (updatedUser == null)
                return NotFound();
            return Ok(updatedUser);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
        
        [Authorize]
        [HttpGet("{id}/ratings")]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetUserRatings(int id)
        {
            var ratings = await _ratingService.GetRatingsByUserAsync(id);
            return Ok(ratings);
        }

       
        [Authorize]
        [HttpGet("{id}/favorites")]
        public async Task<ActionResult<IEnumerable<FavoriteDto>>> GetUserFavorites(int id)
        {
            var favorites = await _favoriteService.GetFavoritesByUserAsync(id);
            return Ok(favorites);
        }

       
        [Authorize]
        [HttpGet("{id}/history")]
        public async Task<ActionResult<IEnumerable<ViewHistoryDto>>> GetUserHistory(int id)
        {
            var history = await _viewHistoryService.GetUserHistoryAsync(id);
            return Ok(history);
        }

        
        [Authorize]
        [HttpGet("{id}/recommendations")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetUserRecommendations(int id, [FromQuery] int count = 5)
        {
            var recs = await _recommendationService.GetRecommendationsForUserAsync(id, count);
            if (recs == null || !recs.Any())
                return NotFound("Nem található ajánlás ehhez a felhasználóhoz.");
            return Ok(recs);
        }
    }
}
