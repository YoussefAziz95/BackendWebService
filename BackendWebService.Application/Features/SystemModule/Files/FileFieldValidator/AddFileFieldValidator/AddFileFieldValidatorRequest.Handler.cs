using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddFileFieldValidatorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddFileFieldValidatorRequest, int>
{
    public IResponse<int> Handle(AddFileFieldValidatorRequest request)
    {
        throw new NotImplementedException();
    }
}