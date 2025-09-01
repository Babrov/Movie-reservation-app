using Microsoft.AspNetCore.Mvc;

namespace MoviesService.Controllers;

[ApiController]
[Route("api/admin/genres")]
public class GenresAdminController : ControllerBase
{
    private readonly MoviesDbContext _db;

    public GenresAdminController(MoviesDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOne()
    {
        return Ok();
    }
}