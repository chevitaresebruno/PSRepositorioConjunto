
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ToDoList.Application.Shared.Exceptions.Filters
{
    public class DatabaseExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DbUpdateException dbUpdateException)
            {
                var errors = dbUpdateException.GetBaseException().Message;
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