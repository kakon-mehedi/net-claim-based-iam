using System;

namespace IAM.Models;

public class UserDetailsModel
{
    public string Id { get; set; }
    public string TenantId { get; set; } = "WoodPanda";
    public string Role { get; set; } = string.Empty;
    public Dictionary<string, string>? CustomClaims { get; set; } = new Dictionary<string, string>();
}
