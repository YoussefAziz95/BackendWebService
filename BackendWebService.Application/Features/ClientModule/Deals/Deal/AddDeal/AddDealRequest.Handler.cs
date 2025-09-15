using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddDealRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddDealRequest, int>
{
    public IResponse<int> Handle(AddDealRequest request)
    {
        throw new NotImplementedException();
    }
}