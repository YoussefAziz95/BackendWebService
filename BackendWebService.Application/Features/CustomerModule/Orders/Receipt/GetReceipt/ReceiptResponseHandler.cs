using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ReceiptResponseHandler : ResponseHandler, IRequestHandler<ReceiptRequest, ReceiptResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReceiptResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ReceiptResponse> Handle(ReceiptRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Receipt>().Get();

        var result = ReceiptResponse.FromEntity(entity);

        return Success(result);
    }
}

