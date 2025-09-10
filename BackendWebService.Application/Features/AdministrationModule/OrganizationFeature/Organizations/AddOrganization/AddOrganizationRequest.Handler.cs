using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddOrganizationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddOrganizationRequest, int>
{
    public IResponse<int> Handle(AddOrganizationRequest request)
    {
        throw new NotImplementedException();
    }
}