using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateServiceRequest, int>
{
    public IResponse<int> Handle(UpdateServiceRequest request)
    {
        throw new NotImplementedException();
    }
}