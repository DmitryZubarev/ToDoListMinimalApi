using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using ToDoApi.Modules.ToDoItems.Data;

namespace ToDoApi.Modules.ToDoItems.Endpoints.Items
{
    public static class GetItemEndpoint
    {
        public static void GetItems(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/items", async ([FromServices] ApplicationDbContext context) =>
            {
                var items = context.Items.ToArray();
                return Results.Ok(items);
            });
        }

        public static void GetItem(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/items{id:guid}", async (Guid id, [FromServices] ApplicationDbContext context) =>
            {
                var item = context.Items.FindAsync(id);
                return Results.Ok(item);
            });
        }
    }
}
