using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class DealDocumentAllResponseHandler : ResponseHandler, IRequestHandler<DealDocumentAllRequest, List<DealDocumentAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealDocumentAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<DealDocumentAllResponse>> Handle(DealDocumentAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<DealDocument>().GetAll();

        var result = entity.Select(DealDocumentAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

