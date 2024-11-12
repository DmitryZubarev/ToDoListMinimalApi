using TodoApi;
using TodoApi.Modules.Common;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTodoApi(builder.Configuration);

var app = builder.Build();
app.MapEndpoints();

app.Run();
