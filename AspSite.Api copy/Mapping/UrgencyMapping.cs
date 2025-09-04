using AspSite.Api.Dtos;
using AspSite.Api.Entities;

namespace AspSite.Api.Mapping;

public static class UrgencyMapping
{
    public static UrgencyDto toDto(this Urgency urgency)
    {
        return new UrgencyDto(urgency.id, urgency.descr);
    }
}
