using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Dtos
{
    
        public class TopRatedMovieDto
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string PosterUrl { get; set; } = string.Empty;
            public List<string> Genres { get; set; } = new();
            public double AverageRating { get; set; }
        }

    

}
