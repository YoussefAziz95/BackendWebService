using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class AddCompanyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCompanyRequest, int>
{
    public IResponse<int> Handle(AddCompanyRequest request)
    {
        throw new NotImplementedException();
    }
}