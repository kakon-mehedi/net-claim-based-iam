using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IAM.Models;
using Microsoft.IdentityModel.Tokens;

namespace IAM.Services.Implementations;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateRefreshToken(User user)
    {
        var claims = new List<Claim> {
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(ClaimTypes.Role, user.Role), 
        new Claim("Department", user.CustomClaims.TryGetValue("Department", out var department) ? department : string.Empty),
        new Claim("Rank", user.CustomClaims.TryGetValue("Rank", out var rank) ? rank : string.Empty), 
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var tokenValidity = DateTime.Now.AddDays(7);

        return GenerateJwtToken(claims, tokenValidity);
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim> {
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim("Department", user.CustomClaims.TryGetValue("Department", out var department) ? department : string.Empty),
        new Claim("Rank", user.CustomClaims.TryGetValue("Rank", out var rank) ? rank : string.Empty),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var tokenValidity = DateTime.Now.AddMinutes(15);

        return GenerateJwtToken(claims, tokenValidity);
    }

    string GenerateJwtToken(List<Claim> claims, DateTime expiresIn)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiresIn,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
