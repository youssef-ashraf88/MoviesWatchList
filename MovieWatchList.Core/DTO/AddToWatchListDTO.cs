using System.ComponentModel.DataAnnotations;

namespace MovieWatchList.DTO
{
    public class AddToWatchListDTO
    {
        [Required(ErrorMessage = "MovieId is required")]
        public Guid MovieId { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "IsWatched is required")]
        public bool IsWatched { get; set; } = false;

        public DateTime? WatchedDate { get; set; }
    }
}
