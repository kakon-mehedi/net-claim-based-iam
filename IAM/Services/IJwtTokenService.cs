using System;
using IAM.Models;

namespace IAM.Services;

public interface IJwtTokenService
{
    public string GenerateToken(User user);
}
