using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateGroupRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateGroupRequest, int>
{
    public IResponse<int> Handle(UpdateGroupRequest request)
    {
        throw new NotImplementedException();
    }
}