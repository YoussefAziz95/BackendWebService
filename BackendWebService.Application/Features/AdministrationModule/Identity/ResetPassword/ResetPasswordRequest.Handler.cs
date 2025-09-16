using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ResetPasswordRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ResetPasswordRequest, int>
{
    public IResponse<int> Handle(ResetPasswordRequest request)
    {
        throw new NotImplementedException();
    }
}