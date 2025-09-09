using AspSite.Api.Data;
using AspSite.Api.Endpoints;
using AspSite.Api.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("todoDb");
builder.Services.AddDbContext<toDoContext>(
    options => options.UseNpgsql(connString)
);

builder.Services.AddScoped<IToDoService, ToDoService>();
var app = builder.Build();
app.MapToDosEndpoints();
app.MapUrgencyEndpoints();

await app.MigrateDbAsync();

app.Run();
