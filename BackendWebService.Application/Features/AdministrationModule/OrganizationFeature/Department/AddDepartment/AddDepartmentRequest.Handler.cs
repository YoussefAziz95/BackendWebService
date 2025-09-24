using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddDepartmentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddDepartmentRequest, int>
{
    public IResponse<int> Handle(AddDepartmentRequest request)
    {
        throw new NotImplementedException();
    }
}