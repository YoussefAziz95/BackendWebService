using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class SupplierCategoryAllResponseHandler : ResponseHandler, IRequestHandler<SupplierCategoryAllRequest, List<SupplierCategoryAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierCategoryAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<SupplierCategoryAllResponse>> Handle(SupplierCategoryAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<SupplierCategory>().GetAll();

        var result = entity.Select(SupplierCategoryAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

