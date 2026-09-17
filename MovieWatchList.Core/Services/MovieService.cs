using AutoMapper;
using MovieWatchList.DTO;
using MovieWatchList.Models;
using MovieWatchList.RepositoryContracts;
using MovieWatchList.ServiceContracts;

namespace MovieWatchList.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieResponseDTO> AddMovie(AddMovieDTO movie)
        {
            var newMovie = _mapper.Map<Movie>(movie);

            await _movieRepository.AddMovie(newMovie);

            var movieResponse = _mapper.Map<MovieResponseDTO>(newMovie);
            return movieResponse;
        }

        public async Task<bool> DeleteMovie(Guid id)
        {
            var movie = await _movieRepository.GetMovieById(id);

            if (movie == null)
                return false;

            await _movieRepository.DeleteMovie(movie);

            return true;
        }

        public async Task<bool> EditMovie(Guid id, EditMovieDTO newData)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if (movie == null)
                return false;

            _mapper.Map(newData, movie);
            await _movieRepository.Save();

            return true;
        }

        public async Task<IEnumerable<MovieResponseDTO>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllMovies();
            var moviesResponse = _mapper.Map<List<MovieResponseDTO>>(movies);

            return moviesResponse;
        }

        public async Task<MovieResponseDTO?> GetMovieById(Guid id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if (movie == null)
                return null;

            var movieResponse = _mapper.Map<MovieResponseDTO>(movie);
            return movieResponse;
        }
    }
}
