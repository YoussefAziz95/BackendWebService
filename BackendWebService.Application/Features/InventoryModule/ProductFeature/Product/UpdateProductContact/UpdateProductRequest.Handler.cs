using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateProductRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateProductRequest, int>
{
    public IResponse<int> Handle(UpdateProductRequest request)
    {
        throw new NotImplementedException();
    }
}