using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateClientPropertyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateClientPropertyRequest, int>
{
    public IResponse<int> Handle(UpdateClientPropertyRequest request)
    {
        throw new NotImplementedException();
    }
}