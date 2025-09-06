namespace MoviesService.Models;

public record MovieDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required int RuntimeMinutes { get; init; }
    public required string Slug { get; init; }
    public required int ReleaseYear { get; init; }
    public required IEnumerable<GenreDto> Genres { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTimeOffset? PublishedAt { get; init; }
    public string? ImageUrl { get; init; }
}