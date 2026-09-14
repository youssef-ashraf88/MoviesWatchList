using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWatchList.Data;
using MovieWatchList.DTO;
using MovieWatchList.Models;
using MovieWatchList.ServiceContracts;

namespace MovieWatchList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IValidator<AddMovieDTO> _validator;
        private readonly IMovieService _movieService;

        public MoviesController(IValidator<AddMovieDTO> validator, IMovieService movieService)
        {
            _validator = validator;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponseDTO>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponseDTO>> GetMovieById(Guid id)
        {
            var Movie = await _movieService.GetMovieById(id);

            if(Movie == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Movie not found"
                });
            }

            return Movie;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieDTO movie)    
        {
            var validationResult = await _validator.ValidateAsync(movie);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var newMovie = await _movieService.AddMovie(movie);

            return CreatedAtAction("GetMovieById", new {id = newMovie.Id}, newMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMovie(Guid id, EditMovieDTO newData)
        {

            var Movie = await _movieService.EditMovie(id, newData);

            if (!Movie)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Movie not found"
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var Movie = await _movieService.DeleteMovie(id);

            if(!Movie)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Movie not found"
                });
            }

            return NoContent();
        }
    }
}
