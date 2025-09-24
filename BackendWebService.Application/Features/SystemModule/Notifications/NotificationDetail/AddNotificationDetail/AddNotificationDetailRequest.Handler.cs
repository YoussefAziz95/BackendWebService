using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddNotificationDetailRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddNotificationDetailRequest, int>
{
    public IResponse<int> Handle(AddNotificationDetailRequest request)
    {
        throw new NotImplementedException();
    }
}