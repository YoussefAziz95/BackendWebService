using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class EmailLogResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmailLogRequest, EmailLogResponse>
{
 
    public IResponse<EmailLogResponse> Handle(EmailLogRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmailLog>().Get();

        var result = EmailLogResponse.FromEntity(entity);

        return Success(result);
    }
}