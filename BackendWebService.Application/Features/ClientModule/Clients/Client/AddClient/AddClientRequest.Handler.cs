using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddClientRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddClientRequest, int>
{
    public IResponse<int> Handle(AddClientRequest request)
    {
        throw new NotImplementedException();
    }
}