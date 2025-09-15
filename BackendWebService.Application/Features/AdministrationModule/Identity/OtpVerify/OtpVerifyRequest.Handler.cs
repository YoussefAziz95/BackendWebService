using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class OtpVerifyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<OtpVerifyRequest, int>
{
    public IResponse<int> Handle(OtpVerifyRequest request)
    {
        throw new NotImplementedException();
    }
}