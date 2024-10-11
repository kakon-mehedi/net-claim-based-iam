using System;

namespace IAM.Models;

public class AuthRequest
{
    required public string Username { get; set; }
    required public string Password { get; set; }
}
