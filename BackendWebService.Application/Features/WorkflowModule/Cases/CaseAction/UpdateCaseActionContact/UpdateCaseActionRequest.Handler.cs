using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCaseActionRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCaseActionRequest, int>
{
    public IResponse<int> Handle(UpdateCaseActionRequest request)
    {
        throw new NotImplementedException();
    }
}