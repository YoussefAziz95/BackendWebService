using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddUserRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddUserRequest, int>
{
    public IResponse<int> Handle(AddUserRequest request)
    {
        throw new NotImplementedException();
    }
}