using TodoApi.Modules.Common;

namespace TodoApi
{
    public static class DI
    {
        public static IServiceCollection AddTodoApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterModules(configuration);
            return services;
        }
    }
}
