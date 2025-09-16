using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddContactRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddContactRequest, int>
{
    public IResponse<int> Handle(AddContactRequest request)
    {
        throw new NotImplementedException();
    }
}