using Microsoft.AspNetCore.Mvc;
using ToDoApi.Modules.ToDoItems.Data;
using ToDoApi.Modules.ToDoItems.Models;

namespace ToDoApi.Modules.ToDoItems.Endpoints.Items
{
    public static class CreateItemEndpoint
    {
        public static void CreateItem(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/items", async (HttpRequest request, [FromServices] ApplicationDbContext context) =>
            {
                var item = await request.ReadFromJsonAsync<Item>();
                
                var newItem = await context.Items.AddAsync(item);
                return Results.Ok(newItem);
            });
        }
    }
}
