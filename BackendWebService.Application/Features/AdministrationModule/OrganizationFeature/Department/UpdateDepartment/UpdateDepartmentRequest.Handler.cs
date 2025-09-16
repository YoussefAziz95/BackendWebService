using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateDepartmentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateDepartmentRequest, int>
{
    public IResponse<int> Handle(UpdateDepartmentRequest request)
    {
        throw new NotImplementedException();
    }
}