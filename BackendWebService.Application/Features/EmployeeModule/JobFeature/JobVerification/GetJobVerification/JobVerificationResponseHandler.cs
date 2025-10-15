using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class JobVerificationResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<JobVerificationResponse>
{

    public IResponse<JobVerificationResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<JobVerification>().GetById(id);

        var result = JobVerificationResponse.FromEntity(entity);

        return Success(result);
    }
}