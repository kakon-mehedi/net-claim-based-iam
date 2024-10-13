using System;
using IAM.Models;

namespace IAM.Services.Validators;

public class LoginModelValidator
{
    public ApiResponseModel validate(LoginModel model)
    {
        var response = new ApiResponseModel();

        if (string.IsNullOrWhiteSpace(model.Username))
        {
            response.SetError(1, "Email cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(model.Password))
        {
            response.SetError(3, "Password cannot be empty.");
        }

        response.SetStatusCode(response.IsSuccess ? 200 : 400);

        return response;
    }
}
