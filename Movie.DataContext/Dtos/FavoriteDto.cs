using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataContext.Dtos
{

    public class FavoriteDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class AddFavoriteDto
    {
        public int MovieId { get; set; }
    }
}
