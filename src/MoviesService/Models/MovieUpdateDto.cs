namespace MoviesService.Models;

public class MovieUpdateDto
{
    public string? Title { get; init; }
    public int? RuntimeMinutes { get; init; }
    public int? ReleaseYear { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? PublishedAt { get; set; }
    public string? ImageUrl { get; set; }
}