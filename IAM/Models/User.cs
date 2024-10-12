using System;

namespace IAM.Models;

public class User
{
    required public int Id { get; set; }
    required public string Username { get; set; }
    required public string PasswordHash { get; set; } // Stored as a hashed password
    required public string Role { get; set; }
}
