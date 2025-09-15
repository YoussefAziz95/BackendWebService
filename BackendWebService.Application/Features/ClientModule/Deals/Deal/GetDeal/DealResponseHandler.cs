using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class DealResponseHandler : ResponseHandler, IRequestHandler<DealRequest, DealResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<DealResponse> Handle(DealRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Deal>().Get();

        var result = DealResponse.FromEntity(entity);

        return Success(result);
    }
}

