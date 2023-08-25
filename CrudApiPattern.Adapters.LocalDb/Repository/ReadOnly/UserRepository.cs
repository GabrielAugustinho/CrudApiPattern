using CrudApiPattern.Adapters.LocalDb.DTOs;
using CrudApiPattern.Core.Application.Abstractions.Read;
using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.OutputPort.User;
using CrudApiPattern.Database.MockedDb.MockedDb;
using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Adapters.LocalDb.Repository.ReadOnly
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserReadOnly
    {
        private readonly IMockedDataBase _mockedDataBase;

        public UserRepository(IMockedDataBase mockedDataBase)
        {
            _mockedDataBase = mockedDataBase;
        }

        public IEnumerable<SearchUserOutput> GetUsers(SearchUserInput input)
        {
            try
            {
                var result = _mockedDataBase.ExecuteGetQuery(id: input.Id, family: input.Familia, name: input.Nome);
                var userDto = new List<UserDto>();

                foreach (var user in result)
                    userDto.Add((UserDto)user);

                return ToOutput(userDto);
            }
            catch
            {
                throw;
            }
        }

        public static IEnumerable<SearchUserOutput> ToOutput(IEnumerable<UserDto> dto)
        {
            var output = new List<SearchUserOutput>();

            foreach (var item in dto)
                output.Add(new SearchUserOutput(item.Id, item.Family, item.Name, item.TotalCount));

            return output;
        }
    }
}
