using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class RecoveryCodeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<RecoveryCodeRequest, int>
{
    public IResponse<int> Handle(RecoveryCodeRequest request)
    {
        throw new NotImplementedException();
    }
}