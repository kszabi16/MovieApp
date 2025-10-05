using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        public int Score { get; set; }   // pl. 1–10
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
