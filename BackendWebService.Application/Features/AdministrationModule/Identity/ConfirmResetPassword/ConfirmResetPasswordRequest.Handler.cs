using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ConfirmResetPasswordRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ConfirmResetPasswordRequest, int>
{
    public IResponse<int> Handle(ConfirmResetPasswordRequest request)
    {
        throw new NotImplementedException();
    }
}