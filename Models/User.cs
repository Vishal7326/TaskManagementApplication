public class User
{
    public int Id { get; set; }  // or string if you use GUIDs

    public string Username { get; set; }

    public byte[] PasswordHash { get; set; }    // add this

    public byte[] PasswordSalt { get; set; }    // add this

    public string Role { get; set; }
}
