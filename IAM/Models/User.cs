using System;
using Microsoft.AspNetCore.Identity;

namespace IAM.Models;

public class User: IdentityUser
{
    required public string Id { get; set; }
    public string Department { get; set; } = string.Empty;
    public string Password { get; set; } // Stored as a hashed password
    public string RefreshToken { get; set; } = string.Empty; // Long life span
    public string Role { get; set; }
}
