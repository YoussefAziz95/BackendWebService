using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddPortionItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddPortionItemRequest, int>
{
    public IResponse<int> Handle(AddPortionItemRequest request)
    {
        throw new NotImplementedException();
    }
}