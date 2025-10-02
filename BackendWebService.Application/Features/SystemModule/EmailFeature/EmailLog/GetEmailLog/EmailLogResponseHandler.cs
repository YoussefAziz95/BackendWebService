using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class EmailLogResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<EmailLogResponse>
{

    public IResponse<EmailLogResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<EmailLog>().GetById(id);

        var result = EmailLogResponse.FromEntity(entity);

        return Success(result);
    }
}