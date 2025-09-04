namespace AspSite.Api.Dtos;

public record class toDoDetailsDto (
    int id,
    string task,
    int urgencyId,
    bool isDone
    );