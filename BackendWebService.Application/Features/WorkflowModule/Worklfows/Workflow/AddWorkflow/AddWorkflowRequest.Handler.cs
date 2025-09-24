using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddWorkflowRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddWorkflowRequest, int>
{
    public IResponse<int> Handle(AddWorkflowRequest request)
    {
        throw new NotImplementedException();
    }
}