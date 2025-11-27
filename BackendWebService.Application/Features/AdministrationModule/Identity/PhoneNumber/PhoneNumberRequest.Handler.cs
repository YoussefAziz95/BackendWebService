using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class PhoneNumberRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PhoneNumberRequest, LoginResponse>
{
    public IResponse<LoginResponse> Handle(PhoneNumberRequest request)
    {
        throw new NotImplementedException();
    }
}