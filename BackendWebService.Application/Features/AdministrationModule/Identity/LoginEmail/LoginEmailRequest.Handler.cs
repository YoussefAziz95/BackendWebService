using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class LoginEmailRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<LoginEmailRequest, int>
{
    public IResponse<int> Handle(LoginEmailRequest request)
    {
        throw new NotImplementedException();
    }
}