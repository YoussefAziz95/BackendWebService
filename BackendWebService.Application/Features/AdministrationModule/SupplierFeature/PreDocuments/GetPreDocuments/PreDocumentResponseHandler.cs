using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class PreDocumentResponseHandler : ResponseHandler, IRequestHandler<PreDocumentRequest, PreDocumentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public PreDocumentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<PreDocumentResponse> Handle(PreDocumentRequest request)
    {
        var entity = _unitOfWork.GenericRepository<PreDocument>().Get();

        var result = PreDocumentResponse.FromEntity(entity);

        return Success(result);
    }
}

