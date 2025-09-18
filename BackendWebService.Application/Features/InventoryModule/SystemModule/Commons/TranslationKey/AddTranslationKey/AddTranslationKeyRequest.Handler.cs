using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddTranslationKeyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddTranslationKeyRequest, int>
{
    public IResponse<int> Handle(AddTranslationKeyRequest request)
    {
        throw new NotImplementedException();
    }
}