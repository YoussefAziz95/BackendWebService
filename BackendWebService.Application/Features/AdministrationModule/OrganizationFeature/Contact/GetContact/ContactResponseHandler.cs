using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ContactResponseHandler : ResponseHandler, IRequestHandler<ContactRequest, ContactResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ContactResponse> Handle(ContactRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Contact>().Get();

        var result = ContactResponse.FromEntity(entity);

        return Success(result);
    }
}

