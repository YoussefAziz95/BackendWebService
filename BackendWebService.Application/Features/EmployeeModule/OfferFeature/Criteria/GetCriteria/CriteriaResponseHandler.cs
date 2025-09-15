using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class CriteriaResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CriteriaRequest, CriteriaResponse>
{
 
    public IResponse<CriteriaResponse> Handle(CriteriaRequest request)
    {
        var entity = unitOfWork.GenericRepository<Criteria>().Get();

        var result = CriteriaResponse.FromEntity(entity);

        return Success(result);
    }
}