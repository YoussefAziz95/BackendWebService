using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateSparePartRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateSparePartRequest, int>
{
    public IResponse<int> Handle(UpdateSparePartRequest request)
    {
        throw new NotImplementedException();
    }
}