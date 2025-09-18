using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateTranslationKeyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateTranslationKeyRequest, int>
{
    public IResponse<int> Handle(UpdateTranslationKeyRequest request)
    {
        throw new NotImplementedException();
    }
}