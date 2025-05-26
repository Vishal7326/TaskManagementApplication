using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.Data;
using TaskManagementApplication.Dtos;
using TaskManagementApplication.Helpers;
using TaskManagementApplication.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IUserServices _userService;
    private readonly JwtTokenHelper _jwt;

    public AuthController(ApplicationDbContext db, IUserServices userService, JwtTokenHelper jwt)
    {
        _db = db;
        _userService = userService;
        _jwt = jwt;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO dto)
    {
        if (await _userService.GetUserByUsername(dto.Username) != null)
            return BadRequest("Username already exists.");

        _userService.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

        var user = new User
        {
            Username = dto.Username,
            PasswordHash = hash,
            PasswordSalt = salt,
            Role = "User"  // default
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return Ok("User registered.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var user = await _userService.GetUserByUsername(dto.Username);
        if (user == null || !_userService.VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
            return Unauthorized("Invalid credentials.");

        var token = _jwt.GenerateToken(user);
        return Ok(new AuthResponseDTO { Token = token });
    }
}
