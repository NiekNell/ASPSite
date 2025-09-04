using AspSite.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspSite.Api.Data;

public class toDoContext(DbContextOptions<toDoContext> options)
: DbContext(options)
{
    public DbSet<toDo> toDos => Set<toDo>();

    public DbSet<Urgency> Urgencies => Set<Urgency>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Urgency>().HasData(
            new { id = 1, level = 1, descr = "Lowest" },
            new { id = 2, level = 2, descr = "Low" },
            new { id = 3, level = 3, descr = "Medium" },
            new { id = 4, level = 4, descr = "High" },
            new { id = 5, level = 5, descr = "Highest" }
        );
    }
}
