using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddSupplierCategoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddSupplierCategoryRequest, int>
{
    public IResponse<int> Handle(AddSupplierCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}