using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class TimeSlotAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<TimeSlotAllRequest, List<TimeSlotAllResponse>>
{
    public IResponse<List<TimeSlotAllResponse>> Handle(TimeSlotAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<TimeSlot>().GetAll();

        var result = entity.Select(TimeSlotAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

