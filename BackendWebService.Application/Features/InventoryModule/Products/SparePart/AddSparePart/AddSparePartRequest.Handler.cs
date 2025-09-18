using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddSparePartRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddSparePartRequest, int>
{
    public IResponse<int> Handle(AddSparePartRequest request)
    {
        throw new NotImplementedException();
    }
}