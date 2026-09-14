using System.ComponentModel.DataAnnotations;

namespace MovieWatchList.DTO
{
    public class EditMovieDTO
    {
        
        public string Title { get; set; } 

        public string Genre { get; set; } 

        [Range(1990, 2026, ErrorMessage = "Release year must be between 1990 and 2026")]
        public int ReleaseYear { get; set; }

        public int DurationMinutes { get; set; }

        [Range(0.0, 10, ErrorMessage = "Rating must be between 0.0 and 10")]
        public decimal? Rating { get; set; }
    }
}
