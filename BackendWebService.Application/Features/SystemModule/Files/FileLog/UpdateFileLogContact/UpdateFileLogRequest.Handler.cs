using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateFileLogRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateFileLogRequest, int>
{
    public IResponse<int> Handle(UpdateFileLogRequest request)
    {
        throw new NotImplementedException();
    }
}