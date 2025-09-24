using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class TransactionResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<TransactionRequest, TransactionResponse>
{

    public IResponse<TransactionResponse> Handle(TransactionRequest request)
    {
        var entity = unitOfWork.GenericRepository<Transaction>().Get();

        var result = TransactionResponse.FromEntity(entity);

        return Success(result);
    }
}