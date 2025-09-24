using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateClientAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateClientAccountRequest, int>
{
    public IResponse<int> Handle(UpdateClientAccountRequest request)
    {
        throw new NotImplementedException();
    }
}