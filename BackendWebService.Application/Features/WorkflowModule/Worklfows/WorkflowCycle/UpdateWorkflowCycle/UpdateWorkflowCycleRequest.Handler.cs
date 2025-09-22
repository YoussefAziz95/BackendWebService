using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateWorkflowCycleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateWorkflowCycleRequest, int>
{
    public IResponse<int> Handle(UpdateWorkflowCycleRequest request)
    {
        throw new NotImplementedException();
    }
}