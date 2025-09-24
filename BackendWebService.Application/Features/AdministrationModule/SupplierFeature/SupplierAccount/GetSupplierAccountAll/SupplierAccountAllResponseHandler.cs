using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class SupplierAccountAllResponseHandler : ResponseHandler, IRequestHandler<SupplierAccountAllRequest, List<SupplierAccountAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierAccountAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<SupplierAccountAllResponse>> Handle(SupplierAccountAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<SupplierAccount>().GetAll();

        var result = entity.Select(SupplierAccountAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

