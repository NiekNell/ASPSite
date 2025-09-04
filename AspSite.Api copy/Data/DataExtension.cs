using Microsoft.EntityFrameworkCore;

namespace AspSite.Api.Data;

public static class DataExtension
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<toDoContext>();
        await db.Database.MigrateAsync();
    }
}
