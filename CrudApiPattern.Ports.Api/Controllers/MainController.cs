using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Ports.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    [ExcludeFromCodeCoverage]
    public class MainController : Controller
    {
        protected BadRequestObjectResult CustomBadRequestResponse(string errorMessage)
        {
            return BadRequest(errorMessage);
        }

        protected OkObjectResult CustomInvalidRequestResponse<T>(string errorMessage)
        {
            return Ok(errorMessage);
        }

        protected OkObjectResult CustomSuccessResponse<T>(T responseValue, string message = "Sucesso")
        {
            return Ok(responseValue);
        }
    }
}
