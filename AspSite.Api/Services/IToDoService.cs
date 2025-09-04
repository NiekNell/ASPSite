using AspSite.Api.Dtos;

namespace AspSite.Api.Services;

public interface IToDoService
{
    Task<List<toDoSummaryDto>> GetToDos();
    Task<toDoDetailsDto?> GetToDoId(int id);
    Task<toDoDetailsDto?> PostToDo(CreateToDoDto NewToDo);
    Task<toDoDetailsDto> PutToDo(int id, UpdateToDoDto updateToDo);
    Task DelToDo(int id);
}
