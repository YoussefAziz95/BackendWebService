using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class SupplierCategoryResponseHandler : ResponseHandler, IRequestByIdHandler<SupplierCategoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierCategoryResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<SupplierCategoryResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<SupplierCategory>().Get();

        var result = SupplierCategoryResponse.FromEntity(entity);

        return Success(result);
    }
}

