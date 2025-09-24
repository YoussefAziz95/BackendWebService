using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class LoggingAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<LoggingAllRequest, List<LoggingAllResponse>>
{
    public IResponse<List<LoggingAllResponse>> Handle(LoggingAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Logging>().GetAll();

        var result = entity.Select(LoggingAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

