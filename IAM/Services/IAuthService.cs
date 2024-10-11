using System;
using IAM.Models;

namespace IAM.Services;

public interface IAuthService
{
    AuthResponse Authenticate(AuthRequest request);
}
