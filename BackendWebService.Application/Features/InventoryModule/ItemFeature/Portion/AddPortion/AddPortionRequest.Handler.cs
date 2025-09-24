using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddPortionRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddPortionRequest, int>
{
    public IResponse<int> Handle(AddPortionRequest request)
    {
        throw new NotImplementedException();
    }
}