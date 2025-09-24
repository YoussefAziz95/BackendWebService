using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class BranchContactResponseHandler : ResponseHandler, IRequestHandler<BranchContactRequest, BranchContactResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchContactResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<BranchContactResponse> Handle(BranchContactRequest request)
    {
        var entity = _unitOfWork.GenericRepository<BranchContact>().Get();

        var result = BranchContactResponse.FromEntity(entity);

        return Success(result);
    }
}

