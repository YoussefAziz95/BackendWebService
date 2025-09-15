using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCriteriaRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCriteriaRequest, int>
{
    public IResponse<int> Handle(UpdateCriteriaRequest request)
    {
        throw new NotImplementedException();
    }
}