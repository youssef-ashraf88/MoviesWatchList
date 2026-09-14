using MovieWatchList.Models;

namespace MovieWatchList.RepositoryContracts
{
    public interface IMovieRepository
    {
        Task AddMovie(Movie movie);

        Task DeleteMovie(Movie movie);

        Task<Movie?> GetMovieById(Guid id);

        Task<IEnumerable<Movie>> GetAllMovies();

        Task Save();
    }
}
