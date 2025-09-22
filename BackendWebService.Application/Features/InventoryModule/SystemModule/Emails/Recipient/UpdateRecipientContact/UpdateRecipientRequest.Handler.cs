using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateRecipientRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateRecipientRequest, int>
{
    public IResponse<int> Handle(UpdateRecipientRequest request)
    {
        throw new NotImplementedException();
    }
}