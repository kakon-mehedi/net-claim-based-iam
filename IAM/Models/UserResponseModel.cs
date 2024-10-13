using System;

namespace IAM.Models;

public class UserResponseModel
{
    required public string Id { get; set; }
    required public string UserName { get; set; }
    required public string Email { get; set; }
    public string? Department { get; set; }
    required public string Role { get; set; }
}
