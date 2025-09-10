using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class OrganizationResponseHandler : ResponseHandler, IRequestHandler<OrganizationRequest, OrganizationResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrganizationResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<OrganizationResponse> Handle(OrganizationRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Organization>().Get();

        var result = OrganizationResponse.FromEntity(entity);

        return Success(result);
    }
}

