using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddEmployeeServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddEmployeeServiceRequest, int>
{
    public IResponse<int> Handle(AddEmployeeServiceRequest request)
    {
        throw new NotImplementedException();
    }
}