using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchContactResponseHandler : ResponseHandler, IRequestByIdHandler<BranchContactResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchContactResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<BranchContactResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<BranchContact>().GetById(id);

        var result = BranchContactResponse.FromEntity(entity);

        return Success(result);
    }
}

