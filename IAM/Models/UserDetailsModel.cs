using System;

namespace IAM.Models;

public class UserDetailsModel
{
    public string Id { get; set; }
    public string TenantId { get; set; } = "WoodPanda";
    public List<string> Roles { get; set; } = new();
    public Dictionary<string, string>? CustomClaims { get; set; } = new Dictionary<string, string>();
}
