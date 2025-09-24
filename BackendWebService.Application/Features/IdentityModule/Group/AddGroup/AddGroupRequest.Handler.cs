using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddGroupRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddGroupRequest, int>
{
    public IResponse<int> Handle(AddGroupRequest request)
    {
        throw new NotImplementedException();
    }
}