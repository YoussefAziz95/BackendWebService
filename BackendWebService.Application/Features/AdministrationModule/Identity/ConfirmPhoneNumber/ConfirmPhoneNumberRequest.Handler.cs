using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ConfirmPhoneNumberRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ConfirmPhoneNumberRequest, int>
{
    public IResponse<int> Handle(ConfirmPhoneNumberRequest request)
    {
        throw new NotImplementedException();
    }
}