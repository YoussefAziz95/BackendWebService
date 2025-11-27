using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class SupplierDocumentAllResponseHandler : ResponseHandler, IRequestHandler<SupplierDocumentAllRequest, List<SupplierDocumentAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierDocumentAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<SupplierDocumentAllResponse>> Handle(SupplierDocumentAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<SupplierDocument>().GetAll();

        var result = entity.Select(SupplierDocumentAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

