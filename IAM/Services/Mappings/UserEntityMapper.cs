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
            Roles = source.Roles,
        };

        user.Password = passwordHasher.HashPassword(user, source.Password);

        return user;
    }
}