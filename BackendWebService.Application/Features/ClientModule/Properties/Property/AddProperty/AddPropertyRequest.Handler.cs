using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddPropertyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddPropertyRequest, int>
{
    public IResponse<int> Handle(AddPropertyRequest request)
    {
        throw new NotImplementedException();
    }
}