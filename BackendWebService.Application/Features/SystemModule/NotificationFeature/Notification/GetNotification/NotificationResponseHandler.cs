using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class NotificationResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<NotificationResponse>
{

    public IResponse<NotificationResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Notification>().GetById(id);

        var result = NotificationResponse.FromEntity(entity);

        return Success(result);
    }
}