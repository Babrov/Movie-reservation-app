using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesService.Data;
using MoviesService.Entities;
using MoviesService.Models;

namespace MoviesService.Controllers;

[ApiController]
[Route("api/admin/movies")]
[Authorize(Roles = "Admin")]
[Produces("application/json")]
public class MoviesAdminController : ControllerBase
{
    private readonly MoviesDbContext _db;

    public MoviesAdminController(MoviesDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MovieDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetList()
    {
        return await (
            from m in _db.Movies
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
    [ProducesResponseType(typeof(MovieDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public IActionResult GetOne([FromRoute] Guid id)
    {
        MovieDto? movie = _db.Movies
            .Where(m => m.Guid == id)
            .Select(m => new MovieDto
            {
                Id = m.Guid,
                Title = m.Title,
                Slug = m.Slug,
                Description = m.Description,
                ReleaseYear = m.ReleaseYear,
                RuntimeMinutes = m.RuntimeMinutes,
                Genres = Array.Empty<GenreDto>()
            })
            .FirstOrDefault();

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    [ProducesResponseType(typeof(MovieDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    public async Task<ActionResult<MovieDto>> Create([FromBody] MovieCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Movie movie = new()
        {
            Title = dto.Title,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            ReleaseYear = dto.ReleaseYear,
            RuntimeMinutes = dto.RuntimeMinutes
        };

        if (await _db.Movies.AnyAsync(m => m.Title == movie.Title))
        {
            return Conflict(new { message = "A movie with the same title already exists." });
        }

        await _db.Movies.AddAsync(movie);
        await _db.SaveChangesAsync();

        return Created(
            $"/api/admin/movies/{movie.Guid}",
            new MovieDto
            {
                Id = movie.Guid,
                Title = movie.Title,
                Slug = movie.Slug,
                Description = movie.Description,
                ReleaseYear = movie.ReleaseYear,
                RuntimeMinutes = movie.RuntimeMinutes,
                Genres = Array.Empty<GenreDto>()
            });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(MovieDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public IActionResult UpdateOne([FromRoute] Guid id, [FromBody] MovieUpdateDto dto)
    {
        Movie? movie = _db.Movies.FirstOrDefault(m => m.Guid == id);
        if (movie == null)
        {
            return NotFound();
        }

        if (dto.Title != null && dto.Title != movie.Title)
        {
            if (_db.Movies.Any(m => m.Title == dto.Title && m.Id != movie.Id))
            {
                return Conflict(new { message = "A movie with the same title already exists." });
            }

            movie.Title = dto.Title;
        }

        if (dto.RuntimeMinutes.HasValue)
        {
            if (dto.RuntimeMinutes <= 0)
            {
                return BadRequest(new { message = "RuntimeMinutes must be greater than zero." });
            }

            movie.RuntimeMinutes = dto.RuntimeMinutes.Value;
        }

        return Ok(new MovieDto
        {
            Id = movie.Guid,
            Title = movie.Title,
            Slug = movie.Slug,
            Description = movie.Description,
            ReleaseYear = movie.ReleaseYear,
            RuntimeMinutes = movie.RuntimeMinutes,
            Genres = Array.Empty<GenreDto>()
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteOne([FromRoute] Guid id)
    {
        Movie? movie = _db.Movies.FirstOrDefault(m => m.Guid == id);

        if (movie == null)
        {
            return NotFound();
        }

        if (movie.PublishedAt != null)
        {
            return BadRequest(new { message = "Cannot delete a published movie." });
        }

        _db.Movies.Remove(movie);
        await _db.SaveChangesAsync();


        return NoContent();
    }
}