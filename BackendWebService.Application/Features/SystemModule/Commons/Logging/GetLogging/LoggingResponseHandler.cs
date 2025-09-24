using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class LoggingResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<LoggingRequest,LoggingResponse>
{
 
    public IResponse<LoggingResponse> Handle(LoggingRequest request)
    {
        var entity = unitOfWork.GenericRepository<Logging>().Get();

        var result =LoggingResponse.FromEntity(entity);

        return Success(result);
    }
}