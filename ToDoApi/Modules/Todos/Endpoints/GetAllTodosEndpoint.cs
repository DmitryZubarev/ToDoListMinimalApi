using Microsoft.EntityFrameworkCore;
using TodoApi.Modules.Todos.Data;

namespace TodoApi.Modules.Todos.Endpoints
{
    public static class GetAllTodosEndpoint
    {
        public static void GetAllTodos(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/", GetAllTodoEntities);
        }

        private static async Task<IResult> GetAllTodoEntities(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.ToArrayAsync());
        }
    }
}
