using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class TranslationKeyAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<TranslationKeyAllRequest, List<TranslationKeyAllResponse>>
{
    public IResponse<List<TranslationKeyAllResponse>> Handle(TranslationKeyAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<TranslationKey>().GetAll();

        var result = entity.Select(TranslationKeyAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

