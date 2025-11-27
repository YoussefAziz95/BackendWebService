using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateReceiptRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateReceiptRequest, int>
{
    public IResponse<int> Handle(UpdateReceiptRequest request)
    {
        throw new NotImplementedException();
    }
}