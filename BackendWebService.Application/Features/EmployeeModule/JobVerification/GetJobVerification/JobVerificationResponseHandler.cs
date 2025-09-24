using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class JobVerificationResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<JobVerificationRequest, JobVerificationResponse>
{

    public IResponse<JobVerificationResponse> Handle(JobVerificationRequest request)
    {
        var entity = unitOfWork.GenericRepository<JobVerification>().Get();

        var result = JobVerificationResponse.FromEntity(entity);

        return Success(result);
    }
}