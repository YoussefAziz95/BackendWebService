using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddClientServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddClientServiceRequest, int>
{
    public IResponse<int> Handle(AddClientServiceRequest request)
    {
        throw new NotImplementedException();
    }
}