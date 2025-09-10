using Domain;

namespace Application.Features;
public record AddServiceRequest(
string Name,
string Description,
string Code,
int CategoryId)
{
    internal Service ToEntity()
    {
        throw new NotImplementedException();
    }
}
