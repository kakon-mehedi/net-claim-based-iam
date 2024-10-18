using System;
using IAM.Models;
using IAM.Repositories;
using IAM.Services.Mappings;
using IAM.Services.Validators;
using Microsoft.AspNetCore.Identity;

namespace IAM.Services.Implementations;

public class UserService : IUserService
{
    private readonly IPasswordHasher<User> _passwordHasher;

    private readonly IJwtTokenService _tokenService;
    private readonly IRepositoryService<User> _repo;

    public UserService(
        IPasswordHasher<User> passwordHasher,
        IJwtTokenService tokenService,
        IRepositoryService<User> repo
    )
    {
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
        _repo = repo;
    }

    public Task<ApiResponseModel> Authenticate(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponseModel> GetUserById(string userId)
    {
        var response = new ApiResponseModel();
        if (string.IsNullOrEmpty(userId))
        {
            response.SetError(0, "UserId can be empty");
            return response;
        }

        var user = await _repo.GetByIdAsync(userId);

        if (user == null)
        {
            response.SetError(0, "User not found");
            return response;
        }

        var data = new UserDetailsModel
        {
            Id = user.Id,
            TenantId = user.TenantId,
            Role = user.Role,
            CustomClaims = user.CustomClaims,
        };

        response.SetData(data);

        return response;

    }

    public async Task<ApiResponseModel> Login(LoginModel model)
    {
        var validator = new LoginModelValidator();
        var response = await Task.Run(() => validator.validate(model));

        if (!response.IsSuccess) return response;

        var user = await _repo.GetItemByFilterAsync((user) => user.Email == model.Email);

        if (user == null)
        {
            response.SetError(401, "Unauthorized");
            return response;
        }

        var passwordValidation = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);

        if (passwordValidation == PasswordVerificationResult.Failed)
        {
            response.SetError(401, "Unauthorized");
            return response;
        }

        var token = _tokenService.GenerateToken(user);

        var data = new AuthResponse
        {
            Token = token,
            Expiration = DateTime.UtcNow,
        };

        response.SetData(data);

        return response;

    }

    public async Task<ApiResponseModel> RegisterUser(UserRegistrationModel model)
    {
        var validator = new UserRegistrationModelValidator();
        var response = await Task.Run(() => validator.validate(model));

        if (!response.IsSuccess) return response;

        var mapper = new UserEntityMapper();
        var user = mapper.MapToUserEntity(model, _passwordHasher);

        await _repo.AddAsync(user);
        await _repo.SaveChangesAsync();

        var data = new UserResponseModel
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role,
        };

        response.SetData(data);

        return response;
    }

    public async Task<ApiResponseModel> UpdateUser(UpdateUserModel updatedUser)
    {
        var validator = new UpdateUserValidator();
        var response = await Task.Run(() => validator.validate(updatedUser));

        if (!response.IsSuccess) return response;

        var user = await _repo.GetByIdAsync(updatedUser.Id);

        if (user == null)
        {
            response.SetError(0, "User not found");
            return response;
        }

        user.CustomClaims = updatedUser.CustomClaims;
        user.Role = updatedUser.Role;

        _repo.Update(user);
        await _repo.SaveChangesAsync();

        var data = new UserResponseModel
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role,
            CustomClaims = user.CustomClaims

        };

        response.SetData(data);

        return response;

    }
}
