using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class ConsumerDocumentResponseHandler : ResponseHandler, IRequestHandler<ConsumerDocumentRequest, ConsumerDocumentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerDocumentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ConsumerDocumentResponse> Handle(ConsumerDocumentRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ConsumerDocument>().Get();

        var result = ConsumerDocumentResponse.FromEntity(entity);

        return Success(result);
    }
}

