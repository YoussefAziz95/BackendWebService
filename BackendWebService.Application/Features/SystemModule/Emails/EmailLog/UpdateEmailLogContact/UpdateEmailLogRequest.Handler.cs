using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateEmailLogRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateEmailLogRequest, int>
{
    public IResponse<int> Handle(UpdateEmailLogRequest request)
    {
        throw new NotImplementedException();
    }
}