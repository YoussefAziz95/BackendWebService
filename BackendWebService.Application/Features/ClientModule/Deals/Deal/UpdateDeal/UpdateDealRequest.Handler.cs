using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateDealRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateDealRequest, int>
{
    public IResponse<int> Handle(UpdateDealRequest request)
    {
        throw new NotImplementedException();
    }
}