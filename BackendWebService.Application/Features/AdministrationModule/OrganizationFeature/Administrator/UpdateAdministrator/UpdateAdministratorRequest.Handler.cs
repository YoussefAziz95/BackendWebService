using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateAdministratorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateAdministratorRequest, int>
{
    public IResponse<int> Handle(UpdateAdministratorRequest request)
    {
        throw new NotImplementedException();
    }
}