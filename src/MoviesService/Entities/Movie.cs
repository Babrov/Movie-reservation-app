using Shared;

namespace MoviesService.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    public string Title { get; init; }
    public string Slug { get; }
    public int RuntimeMinutes { get; init; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public DateTimeOffset? PublishedAt { get; }
    public string? ImageUrl { get; set; }
}