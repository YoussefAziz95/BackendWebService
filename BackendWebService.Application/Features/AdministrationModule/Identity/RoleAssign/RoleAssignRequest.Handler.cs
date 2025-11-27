using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class RoleAssignRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<RoleAssignRequest, int>
{
    public IResponse<int> Handle(RoleAssignRequest request)
    {
        throw new NotImplementedException();
    }
}