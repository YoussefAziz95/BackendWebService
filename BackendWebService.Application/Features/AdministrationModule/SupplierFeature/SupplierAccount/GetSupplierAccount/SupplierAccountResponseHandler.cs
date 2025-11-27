using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class SupplierAccountResponseHandler : ResponseHandler, IRequestByIdHandler<SupplierAccountResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierAccountResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<SupplierAccountResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<SupplierAccount>().GetById(id);

        var result = SupplierAccountResponse.FromEntity(entity);

        return Success(result);
    }
}

