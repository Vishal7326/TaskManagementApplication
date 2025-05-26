using Microsoft.EntityFrameworkCore;
using System.Text;
using TaskManagementApplication.Data;
using TaskManagementApplication.Models;

public class UserServices : IUserServices
{
    private readonly ApplicationDbContext _db;

    public UserServices(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }
}
