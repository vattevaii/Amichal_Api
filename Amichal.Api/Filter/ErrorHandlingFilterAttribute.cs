using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Amichal.Api.Filter
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var excerption = context.Exception;
            var problemDetails = new ProblemDetails
            {
                Instance = context.HttpContext.Request.Path,
                Status = 500,
                Detail = excerption.Message,
                Title = "An exception occured whille processing yout request"
            };
            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
