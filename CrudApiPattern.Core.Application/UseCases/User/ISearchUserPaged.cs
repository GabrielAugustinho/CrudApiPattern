using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.Models;
using CrudApiPattern.Core.Application.OutputPort.User;

namespace CrudApiPattern.Core.Application.UseCases.User
{
    public interface ISearchUserPaged
    {
        PageModel<SearchUserOutput> Execute(SearchUserInput input);
    }
}
