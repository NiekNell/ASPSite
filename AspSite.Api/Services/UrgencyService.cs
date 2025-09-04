using AspSite.Api.Data;
using AspSite.Api.Dtos;
using AspSite.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AspSite.Api.Services;

public class UrgencyService: IUrgencyService
{
    private readonly toDoContext dbContex;
    public UrgencyService(toDoContext dbContex)
    {
        this.dbContex = dbContex;
    }
    public async Task<List<UrgencyDto>> GetUrgencies()
    {
        return await dbContex.Urgencies
            .Select(urgency => urgency.toDto())
            .AsNoTracking()
            .ToListAsync();
    }
}
