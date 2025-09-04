using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCompanyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCompanyRequest, int>
{
    public IResponse<int> Handle(UpdateCompanyRequest request)
    {
        throw new NotImplementedException();
    }
}