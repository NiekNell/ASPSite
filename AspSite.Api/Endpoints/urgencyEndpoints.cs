using AspSite.Api.Services;

namespace AspSite.Api.Endpoints;

public static class urgencyEndpoints
{
    public static RouteGroupBuilder MapUrgencyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/urgencies");

        group.MapGet("/", async (IUrgencyService urgencyService) => urgencyService.GetUrgencies());

        return group;
    }
}
