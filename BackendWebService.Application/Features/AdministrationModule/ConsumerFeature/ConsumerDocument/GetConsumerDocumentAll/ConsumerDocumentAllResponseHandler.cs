using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ConsumerDocumentAllResponseHandler : ResponseHandler, IRequestHandler<ConsumerDocumentAllRequest, List<ConsumerDocumentAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerDocumentAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ConsumerDocumentAllResponse>> Handle(ConsumerDocumentAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ConsumerDocument>().GetAll();

        var result = entity.Select(ConsumerDocumentAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

