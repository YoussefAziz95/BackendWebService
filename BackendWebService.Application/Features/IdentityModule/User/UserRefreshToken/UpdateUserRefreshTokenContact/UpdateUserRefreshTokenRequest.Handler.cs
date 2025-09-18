using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateUserRefreshTokenRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateUserRefreshTokenRequest, int>
{
    public IResponse<int> Handle(UpdateUserRefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }
}