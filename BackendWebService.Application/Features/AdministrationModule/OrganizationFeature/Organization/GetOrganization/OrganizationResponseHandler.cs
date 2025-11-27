using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class OrganizationResponseHandler : ResponseHandler, IRequestByIdHandler<OrganizationResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrganizationResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<OrganizationResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Organization>().GetById(id);

        var result = OrganizationResponse.FromEntity(entity);

        return Success(result);
    }
}

