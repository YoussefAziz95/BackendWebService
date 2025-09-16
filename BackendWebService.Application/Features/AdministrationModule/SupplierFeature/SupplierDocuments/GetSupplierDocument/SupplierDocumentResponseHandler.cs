using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class SupplierDocumentResponseHandler : ResponseHandler, IRequestHandler<SupplierDocumentRequest, SupplierDocumentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierDocumentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<SupplierDocumentResponse> Handle(SupplierDocumentRequest request)
    {
        var entity = _unitOfWork.GenericRepository<SupplierDocument>().Get();

        var result = SupplierDocumentResponse.FromEntity(entity);

        return Success(result);
    }
}

