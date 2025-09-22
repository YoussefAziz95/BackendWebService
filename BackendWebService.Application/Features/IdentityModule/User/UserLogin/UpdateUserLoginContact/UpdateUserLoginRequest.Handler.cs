using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateUserLoginRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateUserLoginRequest, int>
{
    public IResponse<int> Handle(UpdateUserLoginRequest request)
    {
        throw new NotImplementedException();
    }
}