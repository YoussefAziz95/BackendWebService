using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddEmployeeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddEmployeeRequest, int>
{
    public IResponse<int> Handle(AddEmployeeRequest request)
    {
        throw new NotImplementedException();
    }
}