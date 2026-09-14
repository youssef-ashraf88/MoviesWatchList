using FluentValidation;
using MovieWatchList.DTO;

namespace MovieWatchList.Validators
{
    public sealed class AddMovieDTOValidator : AbstractValidator<AddMovieDTO>
    {
        public AddMovieDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");

            RuleFor(x => x.Genre)
                .NotEmpty()
                .WithMessage("Genre is required");

            RuleFor(x => x.ReleaseYear)
                .InclusiveBetween(1990, 2026)
                .WithMessage("Release year must be between 1990 and 2026");

            RuleFor(x => x.DurationMinutes)
                .GreaterThan(0)
                .WithMessage("Duration is required");

            RuleFor(x => x.Rating)
                .NotEmpty()
                .InclusiveBetween(0.0m, 10m)
                .WithMessage("Rating must be between 0.0 and 10");
        }
    }
}
