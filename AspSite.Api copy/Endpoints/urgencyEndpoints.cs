using System;
using AspSite.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace AspSite.Api.Endpoints;

public static class urgencyEndpoints
{
    public static RouteGroupBuilder MapUrgencyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/urgencies");

        group.MapGet("/", async (toDoContext dbContex) =>
            await dbContex.Urgencies
                        .Select(urgency => urgency.descr)
                        .AsNoTracking()
                        .ToListAsync());
        return group;
    }
}
