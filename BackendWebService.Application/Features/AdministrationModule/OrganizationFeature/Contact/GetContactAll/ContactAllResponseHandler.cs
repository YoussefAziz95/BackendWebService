using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ContactAllResponseHandler : ResponseHandler, IRequestHandler<ContactAllRequest, List<ContactAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ContactAllResponse>> Handle(ContactAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Contact>().GetAll();

        var result = entity.Select(ContactAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

