using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateLoggingRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateLoggingRequest, int>
{
    public IResponse<int> Handle(UpdateLoggingRequest request)
    {
        throw new NotImplementedException();
    }
}