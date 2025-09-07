using FluentValidation;

namespace MoviesService.Models;

public class MovieCreateDtoValidator : AbstractValidator<MovieCreateDto>
{
    public MovieCreateDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(x => x.RuntimeMinutes)
            .GreaterThan(0).WithMessage("Runtime must be greater than 0.");

        RuleFor(x => x.ReleaseYear)
            .InclusiveBetween(1888, DateTime.UtcNow.Year + 10)
            .WithMessage($"Release year must be between 1888 and {DateTime.UtcNow.Year + 10}.");
    }
}