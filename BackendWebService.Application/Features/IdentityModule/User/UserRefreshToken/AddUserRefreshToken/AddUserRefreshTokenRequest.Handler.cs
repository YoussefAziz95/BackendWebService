using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddUserRefreshTokenRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddUserRefreshTokenRequest, int>
{
    public IResponse<int> Handle(AddUserRefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }
}