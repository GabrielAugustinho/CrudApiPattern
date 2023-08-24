using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.OutputPort.User;

namespace CrudApiPattern.Core.Application.Abstractions.Read
{
    public interface IUserReadOnly
    {
        IEnumerable<SearchUserOutput> GetUsers(SearchUserInput input);
    }
}
