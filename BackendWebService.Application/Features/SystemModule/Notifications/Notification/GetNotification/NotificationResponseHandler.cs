using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class NotificationResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<NotificationRequest, NotificationResponse>
{
 
    public IResponse<NotificationResponse> Handle(NotificationRequest request)
    {
        var entity = unitOfWork.GenericRepository<Notification>().Get();

        var result = NotificationResponse.FromEntity(entity);

        return Success(result);
    }
}