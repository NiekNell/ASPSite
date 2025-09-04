using AspSite.Api.Dtos;

namespace AspSite.Api.Services;

public interface IUrgencyService
{
    Task<List<UrgencyDto>> GetUrgencies();
}
