using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchResponseHandler : ResponseHandler, IRequestByIdHandler<BranchResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<BranchResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Branch>().GetById(id);

        var result = BranchResponse.FromEntity(entity);

        return Success(result);
    }
}

