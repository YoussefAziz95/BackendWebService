using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class EmailLogAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmailLogAllRequest, List<EmailLogAllResponse>>
{
    public IResponse<List<EmailLogAllResponse>> Handle(EmailLogAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmailLog>().GetAll();

        var result = entity.Select(EmailLogAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

