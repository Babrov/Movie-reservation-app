using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthService;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthDbContext _db;
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(JwtTokenService jwtTokenService, AuthDbContext db)
    {
        _jwtTokenService = jwtTokenService;
        _db = db;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromBody] SignupRequest request)
    {
        if (ModelState.IsValid == false) return BadRequest(ModelState);

        if (await _db.Users.AnyAsync(u => u.Email == request.Email)) return Conflict("Username already exists.");

        string passwordHash = HashPassword(request.Password);

        User user = new(request.Email, passwordHash, request.FirstName, request.LastName);

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return Ok(new { Message = "User signed up successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (ModelState.IsValid == false) return BadRequest(ModelState);

        User? user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null || user.PasswordHash != HashPassword(request.Password))
            return Unauthorized("Invalid credentials.");

        string token = _jwtTokenService.GenerateToken(request.Email!);
        return Ok(new { Token = token });
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        string? email = User.FindFirstValue(ClaimTypes.Email);
        if (email == null) return NotFound();

        return Ok(email);
    }

    private static string HashPassword(string password)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}

public class SignupRequest
{
    [Required] public required string FirstName { get; set; }

    [Required] public required string LastName { get; set; }

    [Required] public required string Password { get; set; }

    [Required] public required string Email { get; set; }
}

public class LoginRequest
{
    [Required] public required string Email { get; set; }

    [Required] public required string Password { get; set; }
}