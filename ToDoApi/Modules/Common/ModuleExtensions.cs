using TodoApi.Modules.Common.Abstractions;

namespace TodoApi.Modules.Common
{
    public static class ModuleExtensions
    {
        private static readonly List<IModule> _registeredModules = new();

        public static IServiceCollection RegisterModules(this IServiceCollection services, IConfiguration configuration)
        {
            var modules = DiscoverModules();

            foreach (var module in modules)
            {
                module.RegisterModules(services, configuration);
                _registeredModules.Add(module);
            }

            return services;
        }

        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
        {
            foreach (var module in _registeredModules)
            {
                module.MapEndpoints(builder);
            }

            return builder;
        }

        private static IEnumerable<IModule> DiscoverModules()
        {
            var neededInterface = typeof(IModule);

            var modules = neededInterface.Assembly
                .GetTypes()
                .Where(t => t.IsClass && t.IsAssignableTo(neededInterface))
                .Select(Activator.CreateInstance)
                .Cast<IModule>();

            return modules;
        }
    }
}
