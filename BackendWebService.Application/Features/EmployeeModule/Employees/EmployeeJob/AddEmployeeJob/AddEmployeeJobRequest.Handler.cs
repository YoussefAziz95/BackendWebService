using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddEmployeeJobRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddEmployeeJobRequest, int>
{
    public IResponse<int> Handle(AddEmployeeJobRequest request)
    {
        throw new NotImplementedException();
    }
}