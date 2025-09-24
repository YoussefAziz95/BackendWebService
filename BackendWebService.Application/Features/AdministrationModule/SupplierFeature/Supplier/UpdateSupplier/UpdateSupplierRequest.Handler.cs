using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateSupplierRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateSupplierRequest, int>
{
    public IResponse<int> Handle(UpdateSupplierRequest request)
    {
        throw new NotImplementedException();
    }
}