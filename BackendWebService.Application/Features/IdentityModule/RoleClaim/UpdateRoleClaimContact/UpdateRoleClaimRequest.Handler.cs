using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateRoleClaimRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateRoleClaimRequest, int>
{
    public IResponse<int> Handle(UpdateRoleClaimRequest request)
    {
        throw new NotImplementedException();
    }
}