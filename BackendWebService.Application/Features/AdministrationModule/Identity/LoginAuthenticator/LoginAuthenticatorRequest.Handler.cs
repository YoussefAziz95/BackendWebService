using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class LoginAuthenticatorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<LoginAuthenticatorRequest, int>
{
    public IResponse<int> Handle(LoginAuthenticatorRequest request)
    {
        throw new NotImplementedException();
    }
}