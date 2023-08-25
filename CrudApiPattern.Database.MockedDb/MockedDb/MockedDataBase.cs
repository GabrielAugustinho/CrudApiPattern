using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Database.MockedDb.MockedDb
{
    [ExcludeFromCodeCoverage]
    public class MockedDataBase : IMockedDataBase
    {
        private List<UserEntity> users;

        public MockedDataBase()
        {
            users = new List<UserEntity>
            {
                new UserEntity(){ Id = 0, Family =  0, Name = "Blitz", TotalCount = 6},
                new UserEntity(){ Id = 1, Family =  0, Name = "Gabriel", TotalCount = 6},
                new UserEntity(){ Id = 2, Family =  0, Name = "Stheppanhy", TotalCount = 6},
                new UserEntity(){ Id = 3, Family =  1, Name = "Larissa", TotalCount = 6},
                new UserEntity(){ Id = 4, Family =  1, Name = "Zezinho", TotalCount = 6},
                new UserEntity(){ Id = 5, Family =  1, Name = "Raquel", TotalCount = 6}
            };
        }

        public IEnumerable<UserEntity> ExecuteGetQuery(int? id, int? family, string? name)
        {
            var usersResponse = from user in users
                                where (id == null || user.Id == id) &&
                                      (family == null || user.Family == family) &&
                                      (string.IsNullOrEmpty(name) || user.Name == name)
                                select user;

            return usersResponse;
        }
    }

    [ExcludeFromCodeCoverage]
    public class UserEntity
    {
        public int Id { get; set; }
        public int Family { get; set; }
        public string Name { get; set; }
        public int TotalCount { get; set; }
    }
}
