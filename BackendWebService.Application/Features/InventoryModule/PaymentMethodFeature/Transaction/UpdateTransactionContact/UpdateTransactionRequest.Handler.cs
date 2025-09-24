using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateTransactionRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateTransactionRequest, int>
{
    public IResponse<int> Handle(UpdateTransactionRequest request)
    {
        throw new NotImplementedException();
    }
}