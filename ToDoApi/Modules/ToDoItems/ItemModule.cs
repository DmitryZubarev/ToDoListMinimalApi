using Microsoft.EntityFrameworkCore;
using ToDoApi.Modules.Common.Abstractions;
using ToDoApi.Modules.ToDoItems.Data;
using ToDoApi.Modules.ToDoItems.Endpoints.Items;
using ToDoApi.Modules.ToDoItems.Endpoints.ItemTypes;

namespace ToDoApi.Modules.ToDoItems
{
    public class ItemModule : IModule
    {
        public IServiceCollection RegisterModules(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase(configuration.GetConnectionString("Default"));
            });

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder builder)
        {
            builder.GetItemTypes();
            builder.GetItemType();
            builder.CreateItemType();

            builder.GetItems();
            builder.GetItem();
            builder.CreateItem();

            return builder;
        }
    }
}
