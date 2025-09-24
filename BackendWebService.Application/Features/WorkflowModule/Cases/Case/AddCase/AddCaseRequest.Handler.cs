using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddCaseRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCaseRequest, int>
{
    public IResponse<int> Handle(AddCaseRequest request)
    {
        throw new NotImplementedException();
    }
}