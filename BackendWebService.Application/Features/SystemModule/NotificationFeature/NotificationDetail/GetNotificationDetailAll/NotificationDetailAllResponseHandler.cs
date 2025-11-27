using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class NotificationDetailAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<NotificationDetailAllRequest, List<NotificationDetailAllResponse>>
{
    public IResponse<List<NotificationDetailAllResponse>> Handle(NotificationDetailAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<NotificationDetail>().GetAll();

        var result = entity.Select(NotificationDetailAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

