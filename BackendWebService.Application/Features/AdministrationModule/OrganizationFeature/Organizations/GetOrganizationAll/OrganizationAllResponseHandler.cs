using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class OrganizationAllResponseHandler : ResponseHandler, IRequestHandler<OrganizationAllRequest, List<OrganizationAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrganizationAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<OrganizationAllResponse>> Handle(OrganizationAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Organization>().GetAll();

        var result = entity.Select(OrganizationAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

