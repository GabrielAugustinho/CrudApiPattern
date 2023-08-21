using CrudApiPattern.Core.Application.UseCases.User;

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

            // Others

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
