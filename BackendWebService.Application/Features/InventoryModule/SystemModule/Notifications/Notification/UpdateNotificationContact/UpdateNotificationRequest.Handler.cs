using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateNotificationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateNotificationRequest, int>
{
    public IResponse<int> Handle(UpdateNotificationRequest request)
    {
        throw new NotImplementedException();
    }
}