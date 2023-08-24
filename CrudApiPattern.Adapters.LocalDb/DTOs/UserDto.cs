using CrudApiPattern.Database.MockedDb.MockedDb;
using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Adapters.LocalDb.DTOs
{
    [ExcludeFromCodeCoverage]
    public class UserDto
    {
        public int Id { get; set; }
        public int Family { get; set; }
        public string Name { get; set; }
        public int TotalCount { get; set; }

        public UserDto(int id, int family, string name, int totalCount)
        {
            Id = id;
            Family = family;
            Name = name;
            TotalCount = totalCount;
        }

        public static explicit operator UserDto(UserEntity userEntity)
        {
            return new UserDto(id: userEntity.Id,
                               family: userEntity.Family,
                               name: userEntity.Name,
                               totalCount: userEntity.TotalCount);
        }
    }
}
