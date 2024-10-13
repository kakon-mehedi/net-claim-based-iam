using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace IAM.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class ProtectedEndPointAttribute : AuthorizeAttribute
{
    public ProtectedEndPointAttribute()
        : base("Protected")
    {
    }
}