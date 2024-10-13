using System;
using IAM.Models;

namespace IAM.Services;

public interface IUserService
{
    Task<ApiResponseModel> RegisterUser(UserRegistrationModel user);
    Task<ApiResponseModel> Login(LoginModel model);
    Task<ApiResponseModel> Authenticate(AuthRequest request);
}
