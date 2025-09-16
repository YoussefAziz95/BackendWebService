using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class RefreshTokenRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<RefreshTokenRequest, int>
{
    public IResponse<int> Handle(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }
}