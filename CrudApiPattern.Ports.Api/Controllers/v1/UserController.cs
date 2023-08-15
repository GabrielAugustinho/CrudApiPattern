using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.OutputPort.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrudApiPattern.Ports.Api.Controllers.v1
{
    [Route("CrudApiPattern/api/")]
    public class UserController : MainController
    {
        private static readonly List<SearchUserOutput> Users = new()
        {
            new SearchUserOutput(){ Id =  0, Name = "Blitz"},
            new SearchUserOutput(){ Id =  1, Name = "Gabriel"},
            new SearchUserOutput(){ Id =  2, Name = "Stheppanhy"},
            new SearchUserOutput(){ Id =  3, Name = "Larissa"},
            new SearchUserOutput(){ Id =  4, Name = "Zezinho"},
            new SearchUserOutput(){ Id =  5, Name = "Raquel"}
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "v1/Select")]
        public IActionResult Select([FromBody] SearchUserInput input)
        {
            try
            {
                var response = Users.Where(x => x.Id.Equals(input.Id));

                return CustomSuccessResponse(response);
            }
            catch
            {
                return CustomBadRequestResponse("Ocorreu uma falha ao listar os usuarios.");
            }
        }
    }
}
