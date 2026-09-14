using MovieWatchList.DTO;
using MovieWatchList.Models;

namespace MovieWatchList.ServiceContracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieResponseDTO>> GetAllMovies();
        
        Task<MovieResponseDTO?> GetMovieById(Guid id);

        Task<MovieResponseDTO?> AddMovie(AddMovieDTO movie);

        Task<bool> DeleteMovie(Guid id);

        Task<bool> EditMovie(Guid id, EditMovieDTO newData);
    }
}
