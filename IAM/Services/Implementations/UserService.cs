using System;
using IAM.Models;
using IAM.Repositories;
using IAM.Services.Mappings;
using IAM.Services.Validations;
using Microsoft.AspNetCore.Identity;

namespace IAM.Services.Implementations;

public class UserService : IUserService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IRepositoryService<User> _repo;

    public UserService(IPasswordHasher<User> passwordHasher, IRepositoryService<User> repo)
    {
        _passwordHasher = passwordHasher;
        _repo = repo;
    }

    public Task<ApiResponseModel> Authenticate(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponseModel> Login(LoginModel model)
    {
        throw new NotImplementedException();
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
            UserName = user.UserName,
            Email = user.Email,
            Department = user.Department,
            Role = user.Role,
        };

        response.SetData(data);

        return response;
    }
}
