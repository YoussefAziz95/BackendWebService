using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateEmployeeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateEmployeeRequest, int>
{
    public IResponse<int> Handle(UpdateEmployeeRequest request)
    {
        throw new NotImplementedException();
    }
}