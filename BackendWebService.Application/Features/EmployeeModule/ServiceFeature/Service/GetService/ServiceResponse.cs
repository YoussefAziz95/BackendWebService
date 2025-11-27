using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record ServiceResponse(
string Name,
string Description,
string Code,
int CategoryId,
 CategoryResponse Category) : IConvertibleFromEntity<Service, ServiceResponse>, IRequest<int>
{
    public static ServiceResponse FromEntity(Service Service) =>
    new ServiceResponse(
    Service.Name,
    Service.Description,
    Service.Code,
    Service.CategoryId,
 CategoryResponse.FromEntity(Service.Category));
}