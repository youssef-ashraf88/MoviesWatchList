using System.ComponentModel.DataAnnotations;

namespace MovieWatchList.DTO
{
    public class MovieResponseDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = "";

        public string Genre { get; set; } = "";

        public int ReleaseYear { get; set; }

        public int DurationMinutes { get; set; }

        public decimal? Rating { get; set; }
    }
}
