using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddRoleClaimRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddRoleClaimRequest, int>
{
    public IResponse<int> Handle(AddRoleClaimRequest request)
    {
        throw new NotImplementedException();
    }
}