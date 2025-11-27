using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ResetPasswordAuthRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ResetPasswordAuthRequest, int>
{
    public IResponse<int> Handle(ResetPasswordAuthRequest request)
    {
        throw new NotImplementedException();
    }
}