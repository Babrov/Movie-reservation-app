using Shared;

namespace MoviesService.Entities;

public class Genre : BaseEntity
{
    public Genre(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
}