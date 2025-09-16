using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateSupplierCategoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateSupplierCategoryRequest, int>
{
    public IResponse<int> Handle(UpdateSupplierCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}