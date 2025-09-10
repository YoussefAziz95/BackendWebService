using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateMicrosoftConfigRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateMicrosoftConfigRequest, int>
{
    public IResponse<int> Handle(UpdateMicrosoftConfigRequest request)
    {
        throw new NotImplementedException();
    }
}