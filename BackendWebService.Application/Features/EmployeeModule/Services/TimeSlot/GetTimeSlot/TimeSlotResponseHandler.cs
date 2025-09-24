using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class TimeSlotResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<TimeSlotRequest, TimeSlotResponse>
{

    public IResponse<TimeSlotResponse> Handle(TimeSlotRequest request)
    {
        var entity = unitOfWork.GenericRepository<TimeSlot>().Get();

        var result = TimeSlotResponse.FromEntity(entity);

        return Success(result);
    }
}