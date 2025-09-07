namespace MoviesService.Models;

public class MovieCreateDto
{
    public string Title { get; init; }
    public int RuntimeMinutes { get; init; }
    public int ReleaseYear { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? PublishedAt { get; }
    public string? ImageUrl { get; set; }
}