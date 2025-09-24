using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddEmployeeAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddEmployeeAccountRequest, int>
{
    public IResponse<int> Handle(AddEmployeeAccountRequest request)
    {
        throw new NotImplementedException();
    }
}