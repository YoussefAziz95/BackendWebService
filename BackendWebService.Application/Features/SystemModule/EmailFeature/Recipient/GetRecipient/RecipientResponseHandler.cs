using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class RecipientResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<RecipientRequest, RecipientResponse>
{

    public IResponse<RecipientResponse> Handle(RecipientRequest request)
    {
        var entity = unitOfWork.GenericRepository<Recipient>().Get();

        var result = RecipientResponse.FromEntity(entity);

        return Success(result);
    }
}