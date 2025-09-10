using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddAdministratorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddAdministratorRequest, int>
{
    public IResponse<int> Handle(AddAdministratorRequest request)
    {
        throw new NotImplementedException();
    }
}