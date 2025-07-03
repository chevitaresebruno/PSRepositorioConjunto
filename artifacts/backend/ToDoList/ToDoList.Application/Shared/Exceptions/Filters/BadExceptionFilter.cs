
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDoList.Domain.Validation;
using System.Linq;
namespace ToDoList.Application.Shared.Exceptions.Filters
{
    public class BadRequestExceptionFilter : IExceptionFilter
    {
        public BadRequestExceptionFilter() { }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationException)
            {
                var errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                var result = new ObjectResult(new { Errors = errors })
                {
                    StatusCode = 400
                };
                context.Result = result;
                context.ExceptionHandled = true;
            }
            else if (context.Exception is DomainValidationException domainValidationException)
            {
                var errors = domainValidationException.Message;
                var result = new ObjectResult(new { Errors = errors })
                {
                    StatusCode = 400
                };
                context.Result = result;
                context.ExceptionHandled = true;
            }
        }
    }
}