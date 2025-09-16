using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class PreDocumentAllResponseHandler : ResponseHandler, IRequestHandler<PreDocumentAllRequest, List<PreDocumentAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PreDocumentAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<PreDocumentAllResponse>> Handle(PreDocumentAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<PreDocument>().GetAll();

        var result = entity.Select(PreDocumentAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

