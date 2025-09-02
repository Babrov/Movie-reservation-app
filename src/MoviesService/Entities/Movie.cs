using Shared;

namespace MoviesService.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    public required string Title { get; init; }
    public string Slug { get; } = string.Empty;
    public int RuntimeMinutes { get; init; }
    public string Description { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public DateTimeOffset? PublishedAt { get; }
    public string? ImageUrl { get; set; }
}