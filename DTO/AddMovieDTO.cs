using System.ComponentModel.DataAnnotations;

namespace MovieWatchList.DTO
{
    public class AddMovieDTO
    {
        //[Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = "";

        //[Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; } = "";

        //[Required]
        //[Range(1990, 2026, ErrorMessage = "Release year must be between 1990 and 2026")]
        public int ReleaseYear { get; set; }

        //[Required(ErrorMessage = "Duration is required")]
        public int DurationMinutes { get; set; }

        //[Required(ErrorMessage = "Rating is required")]
        //[Range(0.0, 10, ErrorMessage = "Rating must be between 0.0 and 10")]
        public decimal? Rating { get; set; }
    }
}
