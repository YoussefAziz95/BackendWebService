using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddTimeSlotRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddTimeSlotRequest, int>
{
    public IResponse<int> Handle(AddTimeSlotRequest request)
    {
        throw new NotImplementedException();
    }
}