using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddSupplierAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddSupplierAccountRequest, int>
{
    public IResponse<int> Handle(AddSupplierAccountRequest request)
    {
        throw new NotImplementedException();
    }
}