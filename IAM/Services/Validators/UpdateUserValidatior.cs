using System;
using IAM.Models;

namespace IAM.Services.Validators;

public class UpdateUserValidator
{
    public ApiResponseModel validate(UpdateUserModel user)
    {
        var response = new ApiResponseModel();

        if (string.IsNullOrWhiteSpace(user.Id))
        {
            response.SetError(0, "User Id can not bue null or empty");
        }

        if (user == null)
        {
            response.SetError(0, "User can not bue null or empty");
        }
        
        response.SetStatusCode(response.IsSuccess ? 200 : 400);

        return response;
    }
}
