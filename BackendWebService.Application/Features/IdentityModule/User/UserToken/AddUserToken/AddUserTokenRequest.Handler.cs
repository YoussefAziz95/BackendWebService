using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddUserTokenRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddUserTokenRequest, int>
{
    public IResponse<int> Handle(AddUserTokenRequest request)
    {
        throw new NotImplementedException();
    }
}