using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Dtos
{

    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = string.Empty;
        public string? PosterUrl { get; set; }
        public double AverageRating { get; set; }

        public List<string> Genres { get; set; } = new();
    }

    public class MovieCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string? PosterUrl { get; set; }
        public string Director { get; set; } = string.Empty;

        public List<int> GenreIds { get; set; } = new();
    }
}
