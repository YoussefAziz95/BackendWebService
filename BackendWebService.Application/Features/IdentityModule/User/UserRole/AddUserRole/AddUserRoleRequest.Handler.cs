using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddUserRoleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddUserRoleRequest, int>
{
    public IResponse<int> Handle(AddUserRoleRequest request)
    {
        throw new NotImplementedException();
    }
}