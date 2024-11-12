using Microsoft.EntityFrameworkCore;
using TodoApi.Modules.Common.Abstractions;
using TodoApi.Modules.Todos.Data;
using TodoApi.Modules.Todos.Endpoints;

namespace TodoApi.Modules.Todos
{
    public class TodoModule : IModule
    {
        public IServiceCollection RegisterModules(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDb>(options =>
            {
                options.UseInMemoryDatabase(configuration.GetConnectionString("InMemory"));
            });
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder builder)
        {
            var todoItems = builder.MapGroup("/todoitems");

            todoItems.GetAllTodos();
            todoItems.GetCompleteTodos();
            todoItems.GetTodo();
            todoItems.CreateTodo();
            todoItems.UpdateTodo();
            todoItems.DeleteTodo();

            return builder;
        }
    }
}
