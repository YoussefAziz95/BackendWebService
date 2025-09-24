using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddUserLoginRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddUserLoginRequest, int>
{
    public IResponse<int> Handle(AddUserLoginRequest request)
    {
        throw new NotImplementedException();
    }
}