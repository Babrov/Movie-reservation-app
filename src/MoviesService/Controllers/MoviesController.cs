using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesService.Data;
using MoviesService.Models;

namespace MoviesService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MoviesDbContext _db;

    public MoviesController(MoviesDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetList()
    {
        return await (
            from m in _db.Movies
            where m.PublishedAt != null
            join mg in _db.MovieGenres on m.Id equals mg.MovieId into movieGenres
            from mg in movieGenres.DefaultIfEmpty()
            join g in _db.Genres on mg.GenreId equals g.Id into genres
            from g in genres.DefaultIfEmpty()
            group new { mg, g } by m
            into grp
            select new MovieDto
            {
                Id = grp.Key.Guid,
                Title = grp.Key.Title,
                Slug = grp.Key.Slug,
                Description = grp.Key.Description,
                ReleaseYear = grp.Key.ReleaseYear,
                RuntimeMinutes = grp.Key.RuntimeMinutes,
                Genres = grp
                    .Where(x => x.g != null)
                    .Select(x => new GenreDto(
                        x.g.Guid,
                        x.g.Name
                    ))
                    .ToArray()
            }
        ).ToArrayAsync();
    }

    [HttpGet("{id}")]
    public IActionResult GetOne([FromRoute] Guid id)
    {
        MovieDto? movie = _db.Movies
            .Where(m => m.Guid == id && m.PublishedAt != null)
            .Select(m => new MovieDto
            {
                Id = m.Guid,
                Title = m.Title,
                Slug = m.Slug,
                Description = m.Description,
                ReleaseYear = m.ReleaseYear,
                RuntimeMinutes = m.RuntimeMinutes,
                Genres = (from mg in _db.MovieGenres
                    where mg.MovieId == m.Id
                    join g in _db.Genres on mg.GenreId equals g.Id
                    select new GenreDto(
                        g.Guid,
                        g.Name
                    )).ToArray()
            })
            .FirstOrDefault();

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }
}