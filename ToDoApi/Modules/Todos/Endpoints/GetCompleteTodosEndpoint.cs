using Microsoft.EntityFrameworkCore;
using TodoApi.Modules.Todos.Data;

namespace TodoApi.Modules.Todos.Endpoints
{
    public static class GetCompleteTodosEndpoint
    {
        public static void GetCompleteTodos(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/complete", GetCompleteTodoEntities);
        }

        private static async Task<IResult> GetCompleteTodoEntities(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).ToListAsync());
        }
    }
}
