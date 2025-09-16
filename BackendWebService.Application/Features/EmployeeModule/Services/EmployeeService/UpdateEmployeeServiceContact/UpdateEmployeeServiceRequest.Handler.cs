using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateEmployeeServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateEmployeeServiceRequest, int>
{
    public IResponse<int> Handle(UpdateEmployeeServiceRequest request)
    {
        throw new NotImplementedException();
    }
}