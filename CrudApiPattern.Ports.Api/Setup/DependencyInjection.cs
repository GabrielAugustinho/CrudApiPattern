namespace CrudApiPattern.Ports.Api.Setup
{
    public static class DependencyInjection
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        public static void RegisterService(this IServiceCollection services)
        {
            // UseCases

            // Abstractions

            // Others

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
