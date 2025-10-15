using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class JobAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<JobAllRequest, List<JobAllResponse>>
{
    public IResponse<List<JobAllResponse>> Handle(JobAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Job>().GetAll();

        var result = entity.Select(JobAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

