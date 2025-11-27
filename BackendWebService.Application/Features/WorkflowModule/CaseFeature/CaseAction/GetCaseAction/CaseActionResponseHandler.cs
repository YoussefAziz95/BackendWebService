using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CaseActionResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<CaseActionResponse>
{

    public IResponse<CaseActionResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<CaseAction>().GetById(id);

        var result = CaseActionResponse.FromEntity(entity);

        return Success(result);
    }
}