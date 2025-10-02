using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ContactResponseHandler : ResponseHandler, IRequestByIdHandler<ContactResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ContactResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Contact>().GetById(id);

        var result = ContactResponse.FromEntity(entity);

        return Success(result);
    }
}

