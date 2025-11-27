using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class CaseResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<CaseResponse>
{

    public IResponse<CaseResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Case>().GetById(id);

        var result = CaseResponse.FromEntity(entity);

        return Success(result);
    }
}