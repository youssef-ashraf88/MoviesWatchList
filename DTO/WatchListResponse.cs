namespace MovieWatchList.DTO
{
    public class WatchListResponse
    {
        public Guid Id { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsWatched { get; set; }

        public DateTime? WatchedDate { get; set; }

        //Movie data

        public Guid MovieId { get; set; }
        public string Title { get; set; } = "";

        public string Genre { get; set; } = "";

        public int ReleaseYear { get; set; }

        public int DurationMinutes { get; set; }

        public decimal? Rating { get; set; }
    }
}
