using TodoApi.Modules.Todos.Data;
using TodoApi.Modules.Todos.Models;

namespace TodoApi.Modules.Todos.Endpoints
{
    public static class DeleteTodoEndpoint
    {
        public static void DeleteTodo(this IEndpointRouteBuilder builder)
        {
            builder.MapDelete("/{id}", DeleteTodoEntity);
        }

        private static async Task<IResult> DeleteTodoEntity(int id, TodoDb db)
        {
            if (await db.Todos.FindAsync(id) is Todo todo)
            {
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }
    }
}
