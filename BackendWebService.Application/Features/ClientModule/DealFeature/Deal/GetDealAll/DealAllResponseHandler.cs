using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class DealAllResponseHandler : ResponseHandler, IRequestHandler<DealAllRequest, List<DealAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<DealAllResponse>> Handle(DealAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Deal>().GetAll();

        var result = entity.Select(DealAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

