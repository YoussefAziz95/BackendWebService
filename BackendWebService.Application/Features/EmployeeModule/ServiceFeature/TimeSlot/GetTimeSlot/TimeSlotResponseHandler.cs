using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class TimeSlotResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<TimeSlotResponse>
{

    public IResponse<TimeSlotResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<TimeSlot>().GetById(id);

        var result = TimeSlotResponse.FromEntity(entity);

        return Success(result);
    }
}