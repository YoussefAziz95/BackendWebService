using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateEmployeeCertificationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateEmployeeCertificationRequest, int>
{
    public IResponse<int> Handle(UpdateEmployeeCertificationRequest request)
    {
        throw new NotImplementedException();
    }
}