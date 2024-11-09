using Microsoft.AspNetCore.Mvc;
using ToDoApi.Modules.ToDoItems.Data;


namespace ToDoApi.Modules.ToDoItems.Endpoints.ItemTypes
{
    public static class GetItemTypesEndpoint
    {
        public static void GetItemTypes(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/itemTypes", async ([FromServices] ApplicationDbContext context) =>
            {
                var types = context.ItemTypes.ToArray();
                return Results.Ok(types);
            });
        }

        public static void GetItemType(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/itemTypes{id:guid}", async (Guid id, [FromServices] ApplicationDbContext context) =>
            {
                var itemType = context.ItemTypes.FindAsync(id);
                return Results.Ok(itemType);
            });
        }
    }
}
