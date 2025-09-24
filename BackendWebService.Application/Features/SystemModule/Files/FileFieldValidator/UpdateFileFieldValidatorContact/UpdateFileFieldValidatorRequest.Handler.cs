using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateFileFieldValidatorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateFileFieldValidatorRequest, int>
{
    public IResponse<int> Handle(UpdateFileFieldValidatorRequest request)
    {
        throw new NotImplementedException();
    }
}