using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddNotificationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddNotificationRequest, int>
{
    public IResponse<int> Handle(AddNotificationRequest request)
    {
        throw new NotImplementedException();
    }
}