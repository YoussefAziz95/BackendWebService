using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ReceiptAllResponseHandler : ResponseHandler, IRequestHandler<ReceiptAllRequest, List<ReceiptAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReceiptAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ReceiptAllResponse>> Handle(ReceiptAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Receipt>().GetAll();

        var result = entity.Select(ReceiptAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

