using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdatePortionItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdatePortionItemRequest, int>
{
    public IResponse<int> Handle(UpdatePortionItemRequest request)
    {
        throw new NotImplementedException();
    }
}