using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class VerifyEmailRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<VerifyEmailRequest, int>
{
    public IResponse<int> Handle(VerifyEmailRequest request)
    {
        throw new NotImplementedException();
    }
}