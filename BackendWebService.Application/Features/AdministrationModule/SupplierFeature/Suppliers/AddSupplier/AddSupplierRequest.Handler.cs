using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddSupplierRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddSupplierRequest, int>
{
    public IResponse<int> Handle(AddSupplierRequest request)
    {
        throw new NotImplementedException();
    }
}