namespace AspSite.Api.Entities;

public class toDo
{
    public int Id { get; set; }
    public required string task { get; set; }

    public int urgencyId { get; set; }
    public Urgency? Urgency { get; set; }
    public bool isDone { get; set; }
}
