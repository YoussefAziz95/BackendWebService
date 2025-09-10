using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateConsumerAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateConsumerAccountRequest, int>
{
    public IResponse<int> Handle(UpdateConsumerAccountRequest request)
    {
        throw new NotImplementedException();
    }
}