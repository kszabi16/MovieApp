using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Dtos
{
    public class MovieEngagementStatsDto
    {
        public int MovieId { get; set; }
        public int FavoriteCount { get; set; }
        public int ViewCount { get; set; }
    }
}

