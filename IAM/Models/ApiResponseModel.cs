using System;

namespace IAM.Models;

public class ApiResponseModel
{
    public string Message { get; set; } = string.Empty;
    public int HttpStatusCode { get; set; } = 500;
    public int TotalCount { get; private set; } = 0;
    public dynamic Data { get; private set; }
    public List<ValidationError> Errors { get; set; } = new List<ValidationError>();
    public bool IsSuccess => Errors.Count > 0 ? false : true;

    public ApiResponseModel SetError(int statusCode, string errorMessage)
    {
        var validationError = new ValidationError
        {
            ErrorCode = statusCode,
            ErrorMessage = errorMessage
        };

        Errors.Add(validationError);
        return this;
    }

    public ApiResponseModel SetSuccess(dynamic data, int statusCode = 200)
    {
        Errors = new List<ValidationError>();
        Data = data;
        HttpStatusCode = statusCode;
        return this;
    }

    public ApiResponseModel SetSuccess()
    {
        Errors = new List<ValidationError>();
        return this;
    }

    public ApiResponseModel SetData(dynamic data)
    {
        Data = data;
        return this;
    }


    public ApiResponseModel SetStatusCode(int statusCode)
    {
        HttpStatusCode = statusCode;
        return this;
    }

    public class ValidationError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }


}