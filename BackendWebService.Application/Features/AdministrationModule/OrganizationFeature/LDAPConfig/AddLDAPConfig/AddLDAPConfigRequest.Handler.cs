using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddLDAPConfigRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddLDAPConfigRequest, int>
{
    public IResponse<int> Handle(AddLDAPConfigRequest request)
    {
        throw new NotImplementedException();
    }
}