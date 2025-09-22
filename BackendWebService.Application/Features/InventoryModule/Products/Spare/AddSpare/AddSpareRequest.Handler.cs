using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddSpareRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddSpareRequest, int>
{
    public IResponse<int> Handle(AddSpareRequest request)
    {
        throw new NotImplementedException();
    }
}