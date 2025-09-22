using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateRoleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateRoleRequest, int>
{
    public IResponse<int> Handle(UpdateRoleRequest request)
    {
        throw new NotImplementedException();
    }
}