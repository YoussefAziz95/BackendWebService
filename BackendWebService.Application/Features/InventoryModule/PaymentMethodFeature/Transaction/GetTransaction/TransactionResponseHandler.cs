using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class TransactionResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<TransactionResponse>
{

    public IResponse<TransactionResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Transaction>().GetById(id);

        var result = TransactionResponse.FromEntity(entity);

        return Success(result);
    }
}