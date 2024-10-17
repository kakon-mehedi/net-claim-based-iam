using System;

namespace IAM.Models;

public class UserRegistrationModel
{
    required public string Email { get; set; }
    required public string TenantId { get; set; }
    required public string Password { get; set; }
    required public string Role { get; set; } = string.Empty;
}
