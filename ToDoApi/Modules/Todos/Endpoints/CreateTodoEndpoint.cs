using Microsoft.AspNetCore.Builder;
using TodoApi.Modules.Todos.Data;
using TodoApi.Modules.Todos.Models;

namespace TodoApi.Modules.Todos.Endpoints
{
    public static class CreateTodoEndpoint
    {
        public static void CreateTodo(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/", CreateTodoEntity);
        }

        private static async Task<IResult> CreateTodoEntity(Todo todo, TodoDb db)
        {
            db.Todos.Add(todo);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/todoitems/{todo.Id}", todo);
        }
    }
}
