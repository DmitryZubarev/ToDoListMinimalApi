using TodoApi.Modules.Todos.Data;
using TodoApi.Modules.Todos.Models;

namespace TodoApi.Modules.Todos.Endpoints
{
    public static class GetTodoEndpoint
    {
        public static void GetTodo(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/{id}", GetTodoEntity);
        }

        private static async Task<IResult> GetTodoEntity(int id, TodoDb db)
        {
            return await db.Todos.FindAsync(id)
                is Todo todo
                    ? TypedResults.Ok(todo)
                    : TypedResults.NotFound();
        }
    }
}
