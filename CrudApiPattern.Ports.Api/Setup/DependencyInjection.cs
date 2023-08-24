using CrudApiPattern.Adapters.LocalDb.Repository.ReadOnly;
using CrudApiPattern.Core.Application.Abstractions.Read;
using CrudApiPattern.Core.Application.UseCases.User;
using CrudApiPattern.Database.MockedDb.MockedDb;

namespace CrudApiPattern.Ports.Api.Setup
{
    public static class DependencyInjection
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        public static void RegisterService(this IServiceCollection services)
        {
            // UseCases
            services.AddScoped<ISearchUserPaged, SearchUserPaged>();

            // Abstractions
            services.AddScoped<IUserReadOnly, UserRepository>();

            // Others
            services.AddScoped<IMockedDataBase, MockedDataBase>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
