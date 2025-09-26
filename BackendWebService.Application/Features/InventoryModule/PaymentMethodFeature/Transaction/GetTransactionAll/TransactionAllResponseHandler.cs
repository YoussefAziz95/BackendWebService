using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class TransactionAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<TransactionAllRequest, List<TransactionAllResponse>>
{
    public IResponse<List<TransactionAllResponse>> Handle(TransactionAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Transaction>().GetAll();

        var result = entity.Select(TransactionAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

