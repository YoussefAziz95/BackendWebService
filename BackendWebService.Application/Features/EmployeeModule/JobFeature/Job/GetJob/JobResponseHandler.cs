using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class JobResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<JobResponse>
{

    public IResponse<JobResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Job>().GetById(id);

        var result = JobResponse.FromEntity(entity);

        return Success(result);
    }
}