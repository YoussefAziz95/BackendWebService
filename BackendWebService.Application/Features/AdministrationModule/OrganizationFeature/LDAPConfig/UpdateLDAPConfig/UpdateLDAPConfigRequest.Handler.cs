using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateLDAPConfigRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateLDAPConfigRequest, int>
{
    public IResponse<int> Handle(UpdateLDAPConfigRequest request)
    {
        throw new NotImplementedException();
    }
}