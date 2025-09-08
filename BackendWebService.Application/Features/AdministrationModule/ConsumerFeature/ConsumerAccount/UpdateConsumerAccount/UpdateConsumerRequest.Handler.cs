using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateConsumerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateConsumerRequest, int>
{
    public IResponse<int> Handle(UpdateConsumerRequest request)
    {
        throw new NotImplementedException();
    }
}