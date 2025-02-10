using System;

namespace IAM.Models;

public class UpdateUserModel
{
    public string Id {get; set;}
    public List<string> Roles { get; set; } = new();
    public Dictionary<string, string>? CustomClaims { get; set; } = new Dictionary<string, string>();
}
