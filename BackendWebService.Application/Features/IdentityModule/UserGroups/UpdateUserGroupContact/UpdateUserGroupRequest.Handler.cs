using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateUserGroupRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateUserGroupRequest, int>
{
    public IResponse<int> Handle(UpdateUserGroupRequest request)
    {
        throw new NotImplementedException();
    }
}