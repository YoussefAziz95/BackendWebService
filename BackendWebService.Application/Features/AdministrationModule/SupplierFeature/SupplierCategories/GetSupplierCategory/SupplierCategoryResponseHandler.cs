using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class SupplierCategoryResponseHandler : ResponseHandler, IRequestHandler<SupplierCategoryRequest, SupplierCategoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierCategoryResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<SupplierCategoryResponse> Handle(SupplierCategoryRequest request)
    {
        var entity = _unitOfWork.GenericRepository<SupplierCategory>().Get();

        var result = SupplierCategoryResponse.FromEntity(entity);

        return Success(result);
    }
}

