using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateUserTokenRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateUserTokenRequest, int>
{
    public IResponse<int> Handle(UpdateUserTokenRequest request)
    {
        throw new NotImplementedException();
    }
}