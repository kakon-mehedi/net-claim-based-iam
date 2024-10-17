using System;
using IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace IAM.Services.Mappings;

public class UserEntityMapper
{
    public User MapToUserEntity(UserRegistrationModel source, IPasswordHasher<User> passwordHasher)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            TenantId = source.TenantId,
            Email = source.Email,
            RefreshToken = string.Empty,
            Role = source.Role,
        };

        user.Password = passwordHasher.HashPassword(user, source.Password);

        return user;
    }
}
