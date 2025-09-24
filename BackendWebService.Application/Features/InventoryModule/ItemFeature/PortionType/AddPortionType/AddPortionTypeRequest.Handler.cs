using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddPortionTypeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddPortionTypeRequest, int>
{
    public IResponse<int> Handle(AddPortionTypeRequest request)
    {
        throw new NotImplementedException();
    }
}