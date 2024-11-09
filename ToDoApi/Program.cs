using ToDoApi;
using ToDoApi.Modules.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddToDoApi(builder.Configuration);
var app = builder.Build();
app.MapEndpoints();

app.Run();
