using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CaseActionResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CaseActionRequest, CaseActionResponse>
{

    public IResponse<CaseActionResponse> Handle(CaseActionRequest request)
    {
        var entity = unitOfWork.GenericRepository<CaseAction>().Get();

        var result = CaseActionResponse.FromEntity(entity);

        return Success(result);
    }
}