using Microsoft.EntityFrameworkCore;
using MovieWatchList.Data;
using MovieWatchList.Models;
using MovieWatchList.RepositoryContracts;

namespace MovieWatchList.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await Save();
        }

        public async Task DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            await Save();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;
        }

        public async Task<Movie?> GetMovieById(Guid id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return movie;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
