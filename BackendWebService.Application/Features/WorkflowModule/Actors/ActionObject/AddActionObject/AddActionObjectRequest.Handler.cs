using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddActionObjectRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddActionObjectRequest, int>
{
    public IResponse<int> Handle(AddActionObjectRequest request)
    {
        throw new NotImplementedException();
    }
}