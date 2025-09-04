using AspSite.Api.Dtos;
using AspSite.Api.Entities;

namespace AspSite.Api.Mapping;

public static class toDoMapping
{

        public static toDo toEntity(this CreateToDoDto toDo)
    {
        return new toDo()
        {
            task = toDo.task,
            urgencyId = toDo.urgencyId,
            isDone = toDo.isDone
        };
    }

        public static toDo toEntity(this UpdateToDoDto toDo, int id)
    {
        return new toDo()
        {
            Id = id,
            task = toDo.task,
            urgencyId = toDo.urgencyId,
            isDone = toDo.isDone
        };
    }

    public static toDoSummaryDto toToDoSummaryDto(this toDo toDo)
    {
        return new(
            toDo.Id,
            toDo.task,
            toDo.Urgency!.level,
            toDo.isDone
        );
    }

    public static toDoDetailsDto toToDoDetailsDto(this toDo toDo)
    {
        return new(
            toDo.Id,
            toDo.task,
            toDo.urgencyId,
            toDo.isDone
        );
    }
}
