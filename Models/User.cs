using Microsoft.AspNetCore.Identity;

namespace learn_dotnet.Models;

public class User : IdentityUser
{
    // public int Id { get; set; }
    // public string Username { get; set; } = string.Empty;
    // public string PasswordHash { get; set; } = string.Empty; // Use hashed passwords


    public string? Initials { get; set; }
}