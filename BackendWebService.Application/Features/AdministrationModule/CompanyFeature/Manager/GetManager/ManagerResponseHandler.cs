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
        var orders = _unitOfWork.GenericRepository<Manager>().Get();

        var result = ManagerResponse.FromEntity(orders);

        return Success(result);
    }
}

