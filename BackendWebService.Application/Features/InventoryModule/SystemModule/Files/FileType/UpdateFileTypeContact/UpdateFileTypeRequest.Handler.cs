using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateFileTypeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateFileTypeRequest, int>
{
    public IResponse<int> Handle(UpdateFileTypeRequest request)
    {
        throw new NotImplementedException();
    }
}