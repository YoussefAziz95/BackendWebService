using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class BranchAllResponseHandler : ResponseHandler, IRequestHandler<BranchAllRequest, List<BranchAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<BranchAllResponse>> Handle(BranchAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Branch>().GetAll();

        var result = entity.Select(BranchAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

