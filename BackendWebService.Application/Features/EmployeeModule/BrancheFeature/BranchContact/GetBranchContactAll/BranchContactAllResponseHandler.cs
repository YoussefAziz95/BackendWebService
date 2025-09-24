using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class BranchContactAllResponseHandler : ResponseHandler, IRequestHandler<BranchContactAllRequest, List<BranchContactAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchContactAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<BranchContactAllResponse>> Handle(BranchContactAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<BranchContact>().GetAll();

        var result = entity.Select(BranchContactAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

