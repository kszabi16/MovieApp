using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Dtos
{
    public class MovieRatingSummaryDto
    {
        public int MovieId { get; set; }
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }
    }
}

