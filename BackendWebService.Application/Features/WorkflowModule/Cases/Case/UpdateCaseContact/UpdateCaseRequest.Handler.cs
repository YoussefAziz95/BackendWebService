using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateCaseRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateCaseRequest, int>
{
    public IResponse<int> Handle(UpdateCaseRequest request)
    {
        throw new NotImplementedException();
    }
}