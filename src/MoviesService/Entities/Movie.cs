using Shared;

namespace MoviesService.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    public Movie(string title, int runtimeMinutes, int releaseYear)
    {
        Title = string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentException("Title cannot be null or whitespace.", nameof(title))
            : title;
        RuntimeMinutes = runtimeMinutes > 0
            ? runtimeMinutes
            : throw new ArgumentOutOfRangeException(nameof(runtimeMinutes),
                "RuntimeMinutes must be greater than zero.");
        ReleaseYear = releaseYear > 1800
            ? releaseYear
            : throw new ArgumentOutOfRangeException(nameof(releaseYear),
                "ReleaseYear must be greater than 1800.");

        Slug = Title.ToLowerInvariant().Replace(' ', '-').Concat($"-{ReleaseYear}").ToString()!;
    }

    private Movie()
    {
    }

    public string Title { get; init; }
    public int RuntimeMinutes { get; init; }
    public string Slug { get; } = string.Empty;
    public int ReleaseYear { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? PublishedAt { get; private set; }
    public string? ImageUrl { get; set; }

    public void Publish()
    {
        if (PublishedAt is not null)
        {
            throw new InvalidOperationException("Movie is already published.");
        }

        if (string.IsNullOrWhiteSpace(Slug))
        {
            throw new InvalidOperationException("Slug cannot be empty when publishing a movie.");
        }

        PublishedAt = DateTimeOffset.UtcNow;
    }
}