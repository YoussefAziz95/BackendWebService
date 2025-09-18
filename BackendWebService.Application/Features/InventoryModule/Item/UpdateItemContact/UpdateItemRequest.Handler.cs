using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateItemRequest, int>
{
    public IResponse<int> Handle(UpdateItemRequest request)
    {
        throw new NotImplementedException();
    }
}