using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCompanyCategoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCompanyCategoryRequest, int>
{
    public IResponse<int> Handle(UpdateCompanyCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}