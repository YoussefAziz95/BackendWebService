using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateWorkflowRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateWorkflowRequest, int>
{
    public IResponse<int> Handle(UpdateWorkflowRequest request)
    {
        throw new NotImplementedException();
    }
}