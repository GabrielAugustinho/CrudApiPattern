using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.OutputPort.User;
using CrudApiPattern.Core.Application.UseCases.User;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiPattern.Ports.Api.Controllers.v1
{
    [Route("CrudApiPattern/api/")]
    public class UserController : MainController
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISearchUserPaged _searchUserPaged;

        public UserController(ILogger<UserController> logger, ISearchUserPaged searchUserPaged)
        {
            _logger = logger;
            _searchUserPaged = searchUserPaged;
        }

        [HttpPost(Name = "v1/SelectUser")]
        public IActionResult SelectUser([FromBody] SearchUserInput input)
        {
            try
            {
                var result = _searchUserPaged.Execute(input);

                return CustomSuccessResponse(result);
            }
            catch
            {
                return CustomBadRequestResponse("Ocorreu uma falha ao listar os usuarios."); 
            }
        }
    }
}
