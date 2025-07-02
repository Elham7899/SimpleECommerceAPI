namespace SimpleECommerceAPI.Models;

public class User
{
    //Identity Key
    public int Id { get; set; }

    //Props
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = "Customer"; // or "Admin"
}

