using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Amichal.Application.Common.Errors;


// Error handling with routing
namespace Amichal.Api.Controllers
{
    [Route("error")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error()
        {
            Exception? exp = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var (statusCode, message) = exp switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status400BadRequest,exp.Message)
            };
            return Problem(statusCode: statusCode, title:message);
        }
    }
}
