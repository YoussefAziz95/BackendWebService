using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddUserClaimRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddUserClaimRequest, int>
{
    public IResponse<int> Handle(AddUserClaimRequest request)
    {
        throw new NotImplementedException();
    }
}