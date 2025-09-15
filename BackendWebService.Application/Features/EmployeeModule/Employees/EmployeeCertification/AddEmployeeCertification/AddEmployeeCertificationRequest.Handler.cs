using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddEmployeeCertificationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddEmployeeCertificationRequest, int>
{
    public IResponse<int> Handle(AddEmployeeCertificationRequest request)
    {
        throw new NotImplementedException();
    }
}