using ToDoApi.Modules.Common;

namespace ToDoApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddToDoApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterModules(configuration);
            return services;
        }
    }
}
