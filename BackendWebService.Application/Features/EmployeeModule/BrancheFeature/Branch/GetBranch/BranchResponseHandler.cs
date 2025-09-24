using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class BranchResponseHandler : ResponseHandler, IRequestHandler<BranchRequest, BranchResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<BranchResponse> Handle(BranchRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Branch>().Get();

        var result = BranchResponse.FromEntity(entity);

        return Success(result);
    }
}

