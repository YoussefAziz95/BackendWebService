using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddCaseActionRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCaseActionRequest, int>
{
    public IResponse<int> Handle(AddCaseActionRequest request)
    {
        throw new NotImplementedException();
    }
}