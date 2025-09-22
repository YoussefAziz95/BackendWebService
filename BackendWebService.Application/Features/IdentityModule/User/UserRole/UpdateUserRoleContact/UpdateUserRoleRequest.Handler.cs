using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateUserRoleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateUserRoleRequest, int>
{
    public IResponse<int> Handle(UpdateUserRoleRequest request)
    {
        throw new NotImplementedException();
    }
}