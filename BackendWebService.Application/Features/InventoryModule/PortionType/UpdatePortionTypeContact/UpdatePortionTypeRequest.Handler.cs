using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdatePortionTypeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdatePortionTypeRequest, int>
{
    public IResponse<int> Handle(UpdatePortionTypeRequest request)
    {
        throw new NotImplementedException();
    }
}