using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class AddConsumerAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddConsumerAccountRequest, int>
{
    public IResponse<int> Handle(AddConsumerAccountRequest request)
    {
        throw new NotImplementedException();
    }
}