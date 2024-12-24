using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SalesApi.Common.Validation;

public static class ValidationExtension
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}
