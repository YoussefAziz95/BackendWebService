using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class MfaRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<MfaRequest, int>
{
    public IResponse<int> Handle(MfaRequest request)
    {
        throw new NotImplementedException();
    }
}