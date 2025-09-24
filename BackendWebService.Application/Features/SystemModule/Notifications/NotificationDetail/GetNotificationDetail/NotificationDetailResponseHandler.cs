using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class NotificationDetailResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<NotificationDetailRequest, NotificationDetailResponse>
{
 
    public IResponse<NotificationDetailResponse> Handle(NotificationDetailRequest request)
    {
        var entity = unitOfWork.GenericRepository<NotificationDetail>().Get();

        var result = NotificationDetailResponse.FromEntity(entity);

        return Success(result);
    }
}