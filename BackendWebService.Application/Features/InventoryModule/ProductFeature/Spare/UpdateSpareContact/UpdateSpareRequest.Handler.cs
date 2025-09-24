using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateSpareRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateSpareRequest, int>
{
    public IResponse<int> Handle(UpdateSpareRequest request)
    {
        throw new NotImplementedException();
    }
}