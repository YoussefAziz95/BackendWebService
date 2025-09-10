using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddClientAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddClientAccountRequest, int>
{
    public IResponse<int> Handle(AddClientAccountRequest request)
    {
        throw new NotImplementedException();
    }
}