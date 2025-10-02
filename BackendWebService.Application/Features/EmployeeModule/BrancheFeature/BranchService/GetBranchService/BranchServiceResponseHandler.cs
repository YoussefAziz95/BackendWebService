using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchServiceResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<BranchServiceResponse>
{

    public IResponse<BranchServiceResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<BranchService>().GetById(id);

        var result = BranchServiceResponse.FromEntity(entity);

        return Success(result);
    }
}