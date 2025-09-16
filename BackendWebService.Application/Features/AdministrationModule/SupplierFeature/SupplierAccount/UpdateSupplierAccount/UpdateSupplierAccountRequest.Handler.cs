using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateSupplierAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateSupplierAccountRequest, int>
{
    public IResponse<int> Handle(UpdateSupplierAccountRequest request)
    {
        throw new NotImplementedException();
    }
}