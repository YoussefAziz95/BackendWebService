using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class DealDocumentResponseHandler : ResponseHandler, IRequestHandler<DealDocumentRequest, DealDocumentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealDocumentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<DealDocumentResponse> Handle(DealDocumentRequest request)
    {
        var entity = _unitOfWork.GenericRepository<DealDocument>().Get();

        var result = DealDocumentResponse.FromEntity(entity);

        return Success(result);
    }
}

