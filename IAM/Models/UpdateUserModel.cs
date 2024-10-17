using System;

namespace IAM.Models;

public class UpdateUserModel
{
    public string Id {get; set;}
    public string Role { get; set; } = string.Empty;
    public Dictionary<string, string>? CustomClaims { get; set; } = new Dictionary<string, string>();
}
