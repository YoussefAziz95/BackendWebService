using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateUserClaimRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateUserClaimRequest, int>
{
    public IResponse<int> Handle(UpdateUserClaimRequest request)
    {
        throw new NotImplementedException();
    }
}