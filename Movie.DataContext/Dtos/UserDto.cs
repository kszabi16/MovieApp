using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Dtos
{
    public class UserStatisticsDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int TotalViews { get; set; }
        public int TotalRatings { get; set; }
        public int TotalFavorites { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class RegisterDto
    {
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }

    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; } 
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public UserDto User { get; set; } = null!;
    }
}
