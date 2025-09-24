using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateClientRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateClientRequest, int>
{
    public IResponse<int> Handle(UpdateClientRequest request)
    {
        throw new NotImplementedException();
    }
}