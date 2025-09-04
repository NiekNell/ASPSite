using AspSite.Api.Data;
using AspSite.Api.Dtos;
using AspSite.Api.Entities;
using AspSite.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AspSite.Api.Services;

public class ToDoService : IToDoService
{
    private readonly toDoContext dbContex;
    public ToDoService(toDoContext dbContex)
    {
        this.dbContex = dbContex;
    }
    public async Task<List<toDoSummaryDto>> GetToDos()
    {
        return await dbContex.toDos
            .Include(toDo => toDo.Urgency)
            .Select(toDo => toDo.toToDoSummaryDto())
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<toDoDetailsDto?> GetToDoId(int id)
    {
        return await dbContex.toDos
            .Include(toDo => toDo.Urgency)
            .Where(toDo => toDo.Id == id)
            .Select(toDo => toDo.toToDoDetailsDto())
            .AsNoTracking()
            .FirstOrDefaultAsync();

    }

    public async Task<toDoDetailsDto> PostToDo(CreateToDoDto NewToDo)
    {
        toDo todo = NewToDo.toEntity();

        dbContex.toDos.Add(todo);
        await dbContex.SaveChangesAsync();

        return todo.toToDoDetailsDto();
    }

    public async Task<toDoDetailsDto?> PutToDo(int id, UpdateToDoDto updateToDo)
    {
        var existingToDo = await dbContex.toDos.FindAsync(id);
        if (existingToDo is null) return null;

        dbContex.Entry(existingToDo).CurrentValues.SetValues(updateToDo.toEntity(id));
        await dbContex.SaveChangesAsync();
        return existingToDo.toToDoDetailsDto();

    }

    public async Task DelToDo(int id)
    { 
        await dbContex.toDos
                .Where(todo => todo.Id == id)
                .ExecuteDeleteAsync();
    }
}
