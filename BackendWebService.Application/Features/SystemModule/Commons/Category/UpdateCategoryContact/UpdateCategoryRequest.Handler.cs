using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCategoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCategoryRequest, int>
{
    public IResponse<int> Handle(UpdateCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}