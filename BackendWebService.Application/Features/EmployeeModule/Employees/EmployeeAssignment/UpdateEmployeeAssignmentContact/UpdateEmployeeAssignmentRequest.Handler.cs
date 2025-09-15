using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateEmployeeAssignmentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateEmployeeAssignmentRequest, int>
{
    public IResponse<int> Handle(UpdateEmployeeAssignmentRequest request)
    {
        throw new NotImplementedException();
    }
}