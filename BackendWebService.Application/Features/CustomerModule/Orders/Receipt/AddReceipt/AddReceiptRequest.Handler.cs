using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddReceiptRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddReceiptRequest, int>
{
    public IResponse<int> Handle(AddReceiptRequest request)
    {
        throw new NotImplementedException();
    }
}