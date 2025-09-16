using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class JobResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<JobRequest, JobResponse>
{
 
    public IResponse<JobResponse> Handle(JobRequest request)
    {
        var entity = unitOfWork.GenericRepository<Job>().Get();

        var result = JobResponse.FromEntity(entity);

        return Success(result);
    }
}