using System.ComponentModel.DataAnnotations;

namespace AspSite.Api.Dtos;

public record class CreateToDoDto(
    [Required] [StringLength(50)] string task,
    int urgencyId,
    [Required] bool isDone
    );
