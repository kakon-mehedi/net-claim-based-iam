using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IAM.Models;

public class User : IdentityUser
{
    public string Id { get; set; }
    public string TenantId { get; set; } = "WoodPanda";
    public string Password { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty; // Long life span
    
    public List<string> Roles { get; set; } = new();
    
    public Dictionary<string, string>? CustomClaims { get; set; } = new Dictionary<string, string>();
}