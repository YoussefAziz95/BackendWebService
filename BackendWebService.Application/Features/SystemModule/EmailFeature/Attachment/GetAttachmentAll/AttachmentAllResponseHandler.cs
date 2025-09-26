using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class AttachmentAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AttachmentAllRequest, List<AttachmentAllResponse>>
{
    public IResponse<List<AttachmentAllResponse>> Handle(AttachmentAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Attachment>().GetAll();

        var result = entity.Select(AttachmentAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

