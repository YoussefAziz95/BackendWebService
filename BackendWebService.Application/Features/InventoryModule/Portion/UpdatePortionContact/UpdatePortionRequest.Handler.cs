using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdatePortionRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdatePortionRequest, int>
{
    public IResponse<int> Handle(UpdatePortionRequest request)
    {
        throw new NotImplementedException();
    }
}