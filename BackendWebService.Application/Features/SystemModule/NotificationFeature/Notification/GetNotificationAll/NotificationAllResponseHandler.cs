using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class NotificationAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<NotificationAllRequest, List<NotificationAllResponse>>
{
    public IResponse<List<NotificationAllResponse>> Handle(NotificationAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Notification>().GetAll();

        var result = entity.Select(NotificationAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

