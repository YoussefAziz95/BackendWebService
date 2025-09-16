using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddMicrosoftConfigRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddMicrosoftConfigRequest, int>
{
    public IResponse<int> Handle(AddMicrosoftConfigRequest request)
    {
        throw new NotImplementedException();
    }
}