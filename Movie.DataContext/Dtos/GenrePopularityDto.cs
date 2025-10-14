using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Dtos
{
    public class GenrePopularityDto
    {
        public int GenreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalMovies { get; set; }
        public int TotalFavorites { get; set; }
        public int TotalViews { get; set; }
    }
}

