using Shared;

namespace MoviesService.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    private string _title = string.Empty;

    private int releaseYear;

    private int runtimeMinutes;

    public Movie()
    {
        Slug = Title.ToLowerInvariant().Replace(' ', '-').Concat($"-{ReleaseYear}").ToString()!;
    }

    public string Title
    {
        get => _title;
        set =>
            _title = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Title cannot be null or whitespace.", nameof(Title))
                : value;
    }

    public int RuntimeMinutes
    {
        get => runtimeMinutes;
        set =>
            runtimeMinutes = value > 0
                ? value
                : throw new ArgumentOutOfRangeException(nameof(RuntimeMinutes),
                    "RuntimeMinutes must be greater than zero.");
    }

    public string Slug { get; } = string.Empty;

    public int ReleaseYear
    {
        get => releaseYear;
        set =>
            releaseYear = value > 1800
                ? value
                : throw new ArgumentOutOfRangeException(nameof(ReleaseYear),
                    "ReleaseYear must be greater than 1800.");
    }

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