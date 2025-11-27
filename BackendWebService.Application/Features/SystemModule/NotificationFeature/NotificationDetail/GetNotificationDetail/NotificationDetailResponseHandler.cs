using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class NotificationDetailResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<NotificationDetailResponse>
{

    public IResponse<NotificationDetailResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<NotificationDetail>().GetById(id);

        var result = NotificationDetailResponse.FromEntity(entity);

        return Success(result);
    }
}