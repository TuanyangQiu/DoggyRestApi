using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoggyRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("HandleGlobalException")]
        public IActionResult HandleGlobalException()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return Problem(detail: exception?.Error.Message, title: "exception occurred!", instance: exception?.Path);
        }

        [Route("HandleErrorCode/{errCode}")]
        public IActionResult HandleErrorCode(int errCode)
        {
            var results = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (errCode == 404)
                return NotFound(new
                {
                    err = "the request resource could not be found",
                    OriginalPath = results?.OriginalPath,
                    OriginalQueryPath = results?.OriginalQueryString
                });

            return Problem(statusCode: errCode, title:"error code handle" );
        }
    }
}
