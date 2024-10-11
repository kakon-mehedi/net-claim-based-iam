using System;

namespace IAM.Models;

public class AuthResponse
{
    required public string Token { get; set; }
    required public DateTime Expiration { get; set; }
}
