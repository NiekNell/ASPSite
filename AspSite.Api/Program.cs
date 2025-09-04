using AspSite.Api.Data;
using AspSite.Api.Endpoints;
using AspSite.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("todoDb");
builder.Services.AddSqlite<toDoContext>(connString);

builder.Services.AddScoped<IToDoService, ToDoService>();
var app = builder.Build();
app.MapToDosEndpoints();
app.MapUrgencyEndpoints();

await app.MigrateDbAsync();

app.Run();
