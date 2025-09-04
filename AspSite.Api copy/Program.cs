using AspSite.Api.Data;
using AspSite.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("todoDb");
builder.Services.AddSqlite<toDoContext>(connString);

var app = builder.Build();
app.MapToDosEndpoints();
app.MapUrgencyEndpoints();

await app.MigrateDbAsync();

app.Run();
