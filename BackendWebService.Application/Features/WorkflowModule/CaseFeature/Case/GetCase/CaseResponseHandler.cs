using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class CaseResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CaseRequest, CaseResponse>
{

    public IResponse<CaseResponse> Handle(CaseRequest request)
    {
        var entity = unitOfWork.GenericRepository<Case>().Get();

        var result = CaseResponse.FromEntity(entity);

        return Success(result);
    }
}