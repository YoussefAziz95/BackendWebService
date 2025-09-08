using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class AddCompanyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCompanyCategoryRequest, int>
{
    public IResponse<int> Handle(AddCompanyCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}