namespace CrudApiPattern.Database.MockedDb.MockedDb
{
    public interface IMockedDataBase
    {
        IEnumerable<UserEntity> ExecuteGetQuery(int? id, int? family, string? name);
    }
}
