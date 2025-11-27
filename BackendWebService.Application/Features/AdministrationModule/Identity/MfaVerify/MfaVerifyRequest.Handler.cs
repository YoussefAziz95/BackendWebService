using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class MfaVerifyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<MfaVerifyRequest, int>
{
    public IResponse<int> Handle(MfaVerifyRequest request)
    {
        throw new NotImplementedException();
    }
}