using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class TranslationKeyResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<TranslationKeyRequest, TranslationKeyResponse>
{
 
    public IResponse<TranslationKeyResponse> Handle(TranslationKeyRequest request)
    {
        var entity = unitOfWork.GenericRepository<TranslationKey>().Get();

        var result = TranslationKeyResponse.FromEntity(entity);

        return Success(result);
    }
}