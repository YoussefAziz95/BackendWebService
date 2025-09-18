using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateUserRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateUserRequest, int>
{
    public IResponse<int> Handle(UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }
}