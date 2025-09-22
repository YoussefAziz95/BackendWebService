using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdatePropertyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdatePropertyRequest, int>
{
    public IResponse<int> Handle(UpdatePropertyRequest request)
    {
        throw new NotImplementedException();
    }
}