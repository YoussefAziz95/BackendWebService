using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class LoggingResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<LoggingResponse>
{

    public IResponse<LoggingResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Logging>().GetById(id);

        var result = LoggingResponse.FromEntity(entity);

        return Success(result);
    }
}