using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddClientPropertyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddClientPropertyRequest, int>
{
    public IResponse<int> Handle(AddClientPropertyRequest request)
    {
        throw new NotImplementedException();
    }
}