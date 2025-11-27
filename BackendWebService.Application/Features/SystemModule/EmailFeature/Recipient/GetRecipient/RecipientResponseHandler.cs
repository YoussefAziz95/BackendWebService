using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class RecipientResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<RecipientResponse>
{

    public IResponse<RecipientResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Recipient>().GetById(id);

        var result = RecipientResponse.FromEntity(entity);

        return Success(result);
    }
}