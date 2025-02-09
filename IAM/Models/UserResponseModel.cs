using System;

namespace IAM.Models;

public class UserResponseModel
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public Dictionary<string, string> CustomClaims { get; set; }

}
