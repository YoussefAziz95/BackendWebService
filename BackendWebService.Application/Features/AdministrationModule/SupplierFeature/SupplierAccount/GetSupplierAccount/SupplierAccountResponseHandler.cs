using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class SupplierAccountResponseHandler : ResponseHandler, IRequestHandler<SupplierAccountRequest, SupplierAccountResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierAccountResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<SupplierAccountResponse> Handle(SupplierAccountRequest request)
    {
        var entity = _unitOfWork.GenericRepository<SupplierAccount>().Get();

        var result = SupplierAccountResponse.FromEntity(entity);

        return Success(result);
    }
}

