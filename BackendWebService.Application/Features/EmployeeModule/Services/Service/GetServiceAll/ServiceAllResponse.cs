using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ServiceAllResponse(
string Name,
string Description,
string Code,
int CategoryId) : IConvertibleFromEntity<Service, ServiceAllResponse>
{
    public static ServiceAllResponse FromEntity(Service Service) =>
    new ServiceAllResponse(
    Service.Name,
    Service.Description,
    Service.Code,
    Service.CategoryId);
}