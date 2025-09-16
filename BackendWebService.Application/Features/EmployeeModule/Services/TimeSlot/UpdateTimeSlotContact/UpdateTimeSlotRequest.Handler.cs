using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateTimeSlotRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateTimeSlotRequest, int>
{
    public IResponse<int> Handle(UpdateTimeSlotRequest request)
    {
        throw new NotImplementedException();
    }
}