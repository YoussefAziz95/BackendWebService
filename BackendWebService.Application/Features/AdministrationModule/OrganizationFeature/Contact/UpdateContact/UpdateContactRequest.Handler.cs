using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateContactRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateContactRequest, int>
{
    public IResponse<int> Handle(UpdateContactRequest request)
    {
        throw new NotImplementedException();
    }
}