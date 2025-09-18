using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdatePartRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdatePartRequest, int>
{
    public IResponse<int> Handle(UpdatePartRequest request)
    {
        throw new NotImplementedException();
    }
}