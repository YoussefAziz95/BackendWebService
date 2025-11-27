using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class OtpVerifyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<OtpVerifyRequest, LoginResponse>
{
    public IResponse<LoginResponse> Handle(OtpVerifyRequest request)
    {
        throw new NotImplementedException();
    }
}