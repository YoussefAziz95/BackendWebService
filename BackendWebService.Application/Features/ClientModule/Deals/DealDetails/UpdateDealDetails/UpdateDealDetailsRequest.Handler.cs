using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateDealDetailsRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateDealDetailsRequest, int>
{
    public IResponse<int> Handle(UpdateDealDetailsRequest request)
    {
        throw new NotImplementedException();
    }
}