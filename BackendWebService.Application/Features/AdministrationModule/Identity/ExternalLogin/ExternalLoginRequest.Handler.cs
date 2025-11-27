using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ExternalLoginRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ExternalLoginRequest, int>
{
    public IResponse<int> Handle(ExternalLoginRequest request)
    {
        throw new NotImplementedException();
    }
}