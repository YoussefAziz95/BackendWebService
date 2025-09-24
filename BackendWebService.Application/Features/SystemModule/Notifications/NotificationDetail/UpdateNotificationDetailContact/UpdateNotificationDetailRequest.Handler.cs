using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateNotificationDetailRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateNotificationDetailRequest, int>
{
    public IResponse<int> Handle(UpdateNotificationDetailRequest request)
    {
        throw new NotImplementedException();
    }
}