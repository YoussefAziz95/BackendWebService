using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class ManagerResponseHandler : ResponseHandler, IRequestHandler<ManagerRequest, ManagerResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ManagerResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ManagerResponse> Handle(ManagerRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Manager>().Get();

        var result = ManagerResponse.FromEntity(entity);

        return Success(result);
    }
}

