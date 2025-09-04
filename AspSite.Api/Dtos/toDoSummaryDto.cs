namespace AspSite.Api.Dtos;

public record class toDoSummaryDto (
    int id,
    string task,
    string urgency,
    bool isDone
    );