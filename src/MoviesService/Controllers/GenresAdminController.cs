using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesService.Data;

namespace MoviesService.Controllers;

[ApiController]
[Route("api/admin/genres")]
[Authorize(Roles = "Admin")]
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