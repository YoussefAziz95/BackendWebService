using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class TwoFactorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<TwoFactorRequest, int>
{
    public IResponse<int> Handle(TwoFactorRequest request)
    {
        throw new NotImplementedException();
    }
}
