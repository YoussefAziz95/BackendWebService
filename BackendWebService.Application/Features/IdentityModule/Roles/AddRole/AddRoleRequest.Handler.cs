using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddRoleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddRoleRequest, int>
{
    public IResponse<int> Handle(AddRoleRequest request)
    {
        throw new NotImplementedException();
    }
}