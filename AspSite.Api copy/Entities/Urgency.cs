namespace AspSite.Api.Entities;

public class Urgency
{
    public int id { get; set; }
    public required int level { get; set; }
    public required string descr { get; set; }
}
