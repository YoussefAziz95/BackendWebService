using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateZoneRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateZoneRequest, int>
{
    public IResponse<int> Handle(UpdateZoneRequest request)
    {
        throw new NotImplementedException();
    }
}