using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddRecipientRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddRecipientRequest, int>
{
    public IResponse<int> Handle(AddRecipientRequest request)
    {
        throw new NotImplementedException();
    }
}