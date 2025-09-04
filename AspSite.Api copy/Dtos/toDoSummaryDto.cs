namespace AspSite.Api.Dtos;

public record class toDoSummaryDto (
    int id,
    string task,
    int urgency,
    bool isDone
    );