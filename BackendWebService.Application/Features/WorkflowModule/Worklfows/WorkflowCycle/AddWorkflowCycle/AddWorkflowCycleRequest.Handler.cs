using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;


namespace Application.Features;


public class AddWorkflowCycleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddWorkflowCycleRequest, int>
{
    public IResponse<int> Handle(AddWorkflowCycleRequest request)
    {
        throw new NotImplementedException();
    }
}