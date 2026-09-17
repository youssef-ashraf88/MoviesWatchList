using System.ComponentModel.DataAnnotations;

namespace MovieWatchList.Models
{
    public class WatchlistItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid MovieId { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsWatched { get; set; }

        public DateTime? WatchedDate { get; set; }

        public Movie? movies { get; set; } 
    }
}
