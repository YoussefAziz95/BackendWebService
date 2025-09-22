using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class RecipientAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<RecipientAllRequest, List<RecipientAllResponse>>
{
    public IResponse<List<RecipientAllResponse>> Handle(RecipientAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Recipient>().GetAll();

        var result = entity.Select(RecipientAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

