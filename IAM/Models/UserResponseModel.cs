using System;

namespace IAM.Models;

public class UserResponseModel
{
    required public string Id { get; set; }
    required public string Email { get; set; }
    required public string Role { get; set; }
    public Dictionary<string, string> CustomClaims { get; set; }

}
