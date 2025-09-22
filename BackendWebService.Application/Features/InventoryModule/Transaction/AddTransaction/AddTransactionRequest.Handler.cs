using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddTransactionRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddTransactionRequest, int>
{
    public IResponse<int> Handle(AddTransactionRequest request)
    {
        throw new NotImplementedException();
    }
}