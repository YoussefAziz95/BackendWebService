using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateClientServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateClientServiceRequest, int>
{
    public IResponse<int> Handle(UpdateClientServiceRequest request)
    {
        throw new NotImplementedException();
    }
}