using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateEmployeeJobRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateEmployeeJobRequest, int>
{
    public IResponse<int> Handle(UpdateEmployeeJobRequest request)
    {
        throw new NotImplementedException();
    }
}