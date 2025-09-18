using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddPartRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddPartRequest, int>
{
    public IResponse<int> Handle(AddPartRequest request)
    {
        throw new NotImplementedException();
    }
}