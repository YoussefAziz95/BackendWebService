using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchLocationResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<BranchLocationResponse>
{

    public IResponse<BranchLocationResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<BranchLocation>().GetById(id);

        var result = BranchLocationResponse.FromEntity(entity);

        return Success(result);
    }
}