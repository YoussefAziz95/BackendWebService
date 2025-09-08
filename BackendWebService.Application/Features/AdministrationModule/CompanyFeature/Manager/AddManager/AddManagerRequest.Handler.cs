using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class AddManagerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddManagerRequest, int>
{
    public IResponse<int> Handle(AddManagerRequest request)
    {
        throw new NotImplementedException();
    }
}