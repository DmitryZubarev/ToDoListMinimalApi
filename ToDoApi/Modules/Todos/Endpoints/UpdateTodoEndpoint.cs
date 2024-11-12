using TodoApi.Modules.Todos.Data;
using TodoApi.Modules.Todos.Models;

namespace TodoApi.Modules.Todos.Endpoints
{
    public static class UpdateTodoEndpoint
    {
        public static void UpdateTodo(this IEndpointRouteBuilder builder)
        {
            builder.MapPut("/{id}", UpdateTodoEntity);
        }

        private static async Task<IResult> UpdateTodoEntity(int id, Todo inputTodo, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return TypedResults.NotFound();

            todo.Name = inputTodo.Name;
            todo.IsComplete = inputTodo.IsComplete;

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }
    }
}
