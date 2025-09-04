namespace AspSite.Api.Endpoints;

using AspSite.Api.Data;
using AspSite.Api.Dtos;
using AspSite.Api.Entities;
using AspSite.Api.Mapping;
using Microsoft.EntityFrameworkCore;

public static class toDosEndpoints
{
    const string endPoint = "getToDo";
    
    public static RouteGroupBuilder MapToDosEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/tasks");

        //Get toDos
        group.MapGet("/", async (toDoContext dbContex) =>
            await dbContex.toDos
            .Include(toDo => toDo.Urgency)
            .Select(toDo => toDo.toToDoSummaryDto())
            .AsNoTracking()
            .ToListAsync());

        //Get toDos/{id}
        group.MapGet("/{id}", async (int id, toDoContext dbContex) =>
        {
            toDo? toDo = await dbContex.toDos.FindAsync(id);
            return toDo is null ? Results.NotFound() : Results.Ok(toDo.toToDoDetailsDto());
        }).WithName(endPoint);

        //Post toDo
        group.MapPost("/", async (CreateToDoDto NewToDo, toDoContext dbContex) =>
        {
            toDo todo = NewToDo.toEntity();


            dbContex.toDos.Add(todo);
            await dbContex.SaveChangesAsync();


            return Results.CreatedAtRoute(endPoint, new { id = todo.Id }, todo.toToDoDetailsDto());
        })
        .WithParameterValidation();

        //Put toDo
        group.MapPut("/{id}", async (int id, UpdateToDoDto updateToDo, toDoContext dbContex) =>
        {
            var existingToDo = await dbContex.toDos.FindAsync(id);
            if (existingToDo is null) return Results.NotFound();

            dbContex.Entry(existingToDo).CurrentValues.SetValues(updateToDo.toEntity(id));
            await dbContex.SaveChangesAsync();
            return Results.NoContent();
        })
        .WithParameterValidation();

        //Delete toDo
        group.MapDelete("/{id}", async (int id, toDoContext dbContex) =>
        {
            await dbContex.toDos
                .Where(todo => todo.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }

}
