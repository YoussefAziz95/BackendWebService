using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class SupplierAllResponseHandler : ResponseHandler, IRequestHandler<SupplierAllRequest, List<SupplierAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<SupplierAllResponse>> Handle(SupplierAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Supplier>().GetAll();

        var result = entity.Select(SupplierAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

