using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IAM.Models;

public class User: IdentityUser
{
    public required string Id { get; set; }
    public required string TenantId { get; set; } = "WoodPanda";
    public string Password { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty; // Long life span
    public string Role { get; set; } = string.Empty;
    public Dictionary<string, string>? CustomClaims { get; set;} = new Dictionary<string, string>();
}
