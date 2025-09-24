using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddZoneRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddZoneRequest, int>
{
    public IResponse<int> Handle(AddZoneRequest request)
    {
        throw new NotImplementedException();
    }
}