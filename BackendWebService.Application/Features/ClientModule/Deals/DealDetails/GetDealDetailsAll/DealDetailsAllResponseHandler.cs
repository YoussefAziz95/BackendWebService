using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class DealDetailsAllResponseHandler : ResponseHandler, IRequestHandler<DealDetailsAllRequest, List<DealDetailsAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealDetailsAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<DealDetailsAllResponse>> Handle(DealDetailsAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<DealDetails>().GetAll();

        var result = entity.Select(DealDetailsAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

