using Microsoft.AspNetCore.Mvc;
using MoviesService.Data;

namespace MoviesService.Controllers;

[ApiController]
[Route("api/admin/movies")]
public class MoviesAdminController : ControllerBase
{
    private readonly MoviesDbContext _db;

    public MoviesAdminController(MoviesDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOne()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOne()
    {
        return Ok();
    }
}