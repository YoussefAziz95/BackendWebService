using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchEmployeeResponseHandler : ResponseHandler, IRequestByIdHandler<BranchEmployeeResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchEmployeeResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<BranchEmployeeResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<BranchEmployee>().GetById(id);

        var result = BranchEmployeeResponse.FromEntity(entity);

        return Success(result);
    }
}

