namespace TodoApi.Modules.Common.Abstractions
{
    public interface IModule
    {
        IServiceCollection RegisterModules(IServiceCollection services, IConfiguration configuration);
        IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder builder);
    }
}
