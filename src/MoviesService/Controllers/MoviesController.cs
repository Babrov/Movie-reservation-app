using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetList()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetOne()
    {
        return Ok();
    }
}