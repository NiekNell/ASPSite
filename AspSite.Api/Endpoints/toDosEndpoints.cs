namespace AspSite.Api.Endpoints;

using AspSite.Api.Dtos;
using AspSite.Api.Services;

public static class toDosEndpoints
{
    const string endPoint = "getToDo";
    
    public static RouteGroupBuilder MapToDosEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/tasks");

        //Get toDos
        group.MapGet("/", async (IToDoService toDoService) => toDoService.GetToDos());


        //Get toDos/{id}
        group.MapGet("/{id}", async (int id, IToDoService toDoService) => toDoService.GetToDoId(id))
            .WithName(endPoint);

        //Post toDo
        group.MapPost("/", async (CreateToDoDto NewToDo, IToDoService toDoService) =>
        {
            var detailsDto = await toDoService.PostToDo(NewToDo);

            return Results.CreatedAtRoute(endPoint, new { id = detailsDto!.id }, detailsDto);
        })
            .WithParameterValidation();

        //Put toDo
        group.MapPut("/{id}", async (int id, UpdateToDoDto updateToDo, IToDoService toDoService) =>
        {
            var updatedToDo = await toDoService.PutToDo(id, updateToDo);
            if (updatedToDo is null) 
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        })
            .WithParameterValidation();

        //Delete toDo
        group.MapDelete("/{id}", async (int id, IToDoService toDoService) =>
        {
            await toDoService.DelToDo(id);
            return Results.NoContent();
        });

        return group;
    }

}
