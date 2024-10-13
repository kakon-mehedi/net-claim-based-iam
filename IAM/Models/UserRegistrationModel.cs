using System;

namespace IAM.Models;

public class UserRegistrationModel
{
    required public string UserName { get; set; }
    required public string Email { get; set; }
    public string? Department { get; set; }
    required public string Password { get; set; }
    required public string Role { get; set; }
}
