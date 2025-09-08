using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class AddConsumerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddConsumerRequest, int>
{
    public IResponse<int> Handle(AddConsumerRequest request)
    {
        throw new NotImplementedException();
    }
}