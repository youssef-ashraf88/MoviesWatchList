using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieWatchList.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = "";

        public string Genre { get; set; } = "";

        public int ReleaseYear { get; set; }

        public int DurationMinutes { get; set; }

        public decimal? Rating { get; set; }

        //[JsonIgnore]
        public IEnumerable<WatchlistItem> watchlistItem { get; set; } = new List<WatchlistItem>();
    }
}
