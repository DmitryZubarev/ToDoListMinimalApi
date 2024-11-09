using Microsoft.AspNetCore.Mvc;
using ToDoApi.Modules.ToDoItems.Data;

namespace ToDoApi.Modules.ToDoItems.Endpoints.ItemTypes
{
    public static class CreateItemTypeEndpoint
    {
        public static void CreateItemType(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/itemTypes{name:string}", async (string name, [FromServices] ApplicationDbContext context) =>
            {
                var type = await context.ItemTypes.FindAsync(name);

                if (type is null)
                {
                    var newType = await context.ItemTypes.AddAsync(type);
                    return Results.Ok(newType);
                }

                return Results.Conflict("Type with this name is exists");
            });
        }
    }
}
