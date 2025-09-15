using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class JobVerificationAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<JobVerificationAllRequest, List<JobVerificationAllResponse>>
{
    public IResponse<List<JobVerificationAllResponse>> Handle(JobVerificationAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<JobVerification>().GetAll();

        var result = entity.Select(JobVerificationAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

