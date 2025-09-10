using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateOrganizationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateOrganizationRequest, int>
{
    public IResponse<int> Handle(UpdateOrganizationRequest request)
    {
        throw new NotImplementedException();
    }
}