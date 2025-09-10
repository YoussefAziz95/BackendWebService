using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class SupplierResponseHandler : ResponseHandler, IRequestHandler<SupplierRequest, SupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<SupplierResponse> Handle(SupplierRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Supplier>().Get();

        var result = SupplierResponse.FromEntity(entity);

        return Success(result);
    }
}

