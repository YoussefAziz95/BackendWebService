using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddEmployeeAssignmentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddEmployeeAssignmentRequest, int>
{
    public IResponse<int> Handle(AddEmployeeAssignmentRequest request)
    {
        throw new NotImplementedException();
    }
}