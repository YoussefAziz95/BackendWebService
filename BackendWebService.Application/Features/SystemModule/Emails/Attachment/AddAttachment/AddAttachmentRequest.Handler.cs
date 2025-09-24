using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddAttachmentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddAttachmentRequest, int>
{
    public IResponse<int> Handle(AddAttachmentRequest request)
    {
        throw new NotImplementedException();
    }
}