using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class SupplierDocumentResponseHandler : ResponseHandler, IRequestByIdHandler<SupplierDocumentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierDocumentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<SupplierDocumentResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<SupplierDocument>().GetById(id);

        var result = SupplierDocumentResponse.FromEntity(entity);

        return Success(result);
    }
}

