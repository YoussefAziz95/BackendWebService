using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateJobVerificationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateJobVerificationRequest, int>
{
    public IResponse<int> Handle(UpdateJobVerificationRequest request)
    {
        throw new NotImplementedException();
    }
}