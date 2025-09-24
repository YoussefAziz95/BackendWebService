using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateAttachmentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateAttachmentRequest, int>
{
    public IResponse<int> Handle(UpdateAttachmentRequest request)
    {
        throw new NotImplementedException();
    }
}