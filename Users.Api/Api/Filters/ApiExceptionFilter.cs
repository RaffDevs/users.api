using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Users.Api.Application.Exceptions;

namespace Users.Api.Api.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {

        switch (context.Exception)
        {
            case NotFoundException:
                context.Result = new NotFoundObjectResult(context.Exception.Message);
                break;
            default:
                var result = new ObjectResult(context.Exception.Message);
                result.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = result;
                break;
        }
    }
}