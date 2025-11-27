using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class TranslationKeyResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<TranslationKeyResponse>
{

    public IResponse<TranslationKeyResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<TranslationKey>().GetById(id);

        var result = TranslationKeyResponse.FromEntity(entity);

        return Success(result);
    }
}