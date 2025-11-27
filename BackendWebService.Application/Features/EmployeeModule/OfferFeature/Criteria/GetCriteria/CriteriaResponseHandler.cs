using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CriteriaResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<CriteriaResponse>
{

    public IResponse<CriteriaResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Criteria>().GetById(id);

        var result = CriteriaResponse.FromEntity(entity);

        return Success(result);
    }
}