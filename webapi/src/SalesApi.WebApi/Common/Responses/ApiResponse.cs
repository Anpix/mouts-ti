﻿using SalesApi.Common.Validation;

namespace SalesApi.WebApi.Common.Responses;

public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];
}