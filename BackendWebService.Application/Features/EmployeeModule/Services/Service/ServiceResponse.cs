using Domain;

namespace Application.Features;
public record ServiceResponse(
string Name,
string Description,
string Code,
int CategoryId)
{
    internal static ServiceResponse? FromEntity(Service? service)
    {
        throw new NotImplementedException();
    }
}
