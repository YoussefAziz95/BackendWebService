using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddUserGroupRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddUserGroupRequest, int>
{
    public IResponse<int> Handle(AddUserGroupRequest request)
    {
        throw new NotImplementedException();
    }
}