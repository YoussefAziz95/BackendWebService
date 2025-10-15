using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class SupplierResponseHandler : ResponseHandler, IRequestByIdHandler<SupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<SupplierResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Supplier>().GetById(id);

        var result = SupplierResponse.FromEntity(entity);

        return Success(result);
    }
}

