using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class AttachmentResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<AttachmentResponse>
{

    public IResponse<AttachmentResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Attachment>().GetById(id);

        var result = AttachmentResponse.FromEntity(entity);

        return Success(result);
    }
}