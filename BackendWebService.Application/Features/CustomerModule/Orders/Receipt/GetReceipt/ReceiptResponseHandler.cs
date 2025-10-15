using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ReceiptResponseHandler : ResponseHandler, IRequestByIdHandler<ReceiptResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReceiptResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ReceiptResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Receipt>().GetById(id);

        var result = ReceiptResponse.FromEntity(entity);

        return Success(result);
    }
}

