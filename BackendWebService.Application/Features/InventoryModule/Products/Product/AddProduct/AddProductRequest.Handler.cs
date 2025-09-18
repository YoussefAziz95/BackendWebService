using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddProductRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddProductRequest, int>
{
    public IResponse<int> Handle(AddProductRequest request)
    {
        throw new NotImplementedException();
    }
}