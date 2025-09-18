using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class AttachmentResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AttachmentRequest, AttachmentResponse>
{
 
    public IResponse<AttachmentResponse> Handle(AttachmentRequest request)
    {
        var entity = unitOfWork.GenericRepository<Attachment>().Get();

        var result = AttachmentResponse.FromEntity(entity);

        return Success(result);
    }
}