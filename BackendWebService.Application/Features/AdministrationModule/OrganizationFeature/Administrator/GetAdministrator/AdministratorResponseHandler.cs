using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class AdministratorResponseHandler : ResponseHandler, IRequestHandler<AdministratorRequest, AdministratorResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AdministratorResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<AdministratorResponse> Handle(AdministratorRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Administrator>().Get();

        var result = AdministratorResponse.FromEntity(entity);

        return Success(result);
    }
}

