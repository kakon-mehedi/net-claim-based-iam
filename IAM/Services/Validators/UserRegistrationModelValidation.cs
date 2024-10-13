using System;
using IAM.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IAM.Services.Validators;

public class UserRegistrationModelValidator
{
    public ApiResponseModel validate(UserRegistrationModel model)
    {
        var response = new ApiResponseModel();

        if (string.IsNullOrWhiteSpace(model.Email))
        {
            response.SetError(1, "Email cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(model.UserName))
        {
            response.SetError(2, "Username cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(model.Password))
        {
            response.SetError(3, "Password cannot be empty.");
        }
        else if (model.Password.Length < 6)
        {
            response.SetError(4, "Password must be at least 6 characters long.");
        }

        if (string.IsNullOrWhiteSpace(model.Role))
        {
            response.SetError(5, "Password cannot be empty.");
        }

        response.SetStatusCode(response.IsSuccess ? 200 : 400);

        return response;
    }
}
