using TaskManagementApplication.Models;

public interface IUserServices
{
    Task<User?> GetUserByUsername(string username);
    void CreatePasswordHash(string password, out byte[] hash, out byte[] salt);
    bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
}
