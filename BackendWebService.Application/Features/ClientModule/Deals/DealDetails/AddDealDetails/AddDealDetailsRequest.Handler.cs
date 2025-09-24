using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddDealDetailsRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddDealDetailsRequest, int>
{
    public IResponse<int> Handle(AddDealDetailsRequest request)
    {
        throw new NotImplementedException();
    }
}