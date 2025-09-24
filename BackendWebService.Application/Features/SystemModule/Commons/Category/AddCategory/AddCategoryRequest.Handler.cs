using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddCategoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCategoryRequest, int>
{
    public IResponse<int> Handle(AddCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}