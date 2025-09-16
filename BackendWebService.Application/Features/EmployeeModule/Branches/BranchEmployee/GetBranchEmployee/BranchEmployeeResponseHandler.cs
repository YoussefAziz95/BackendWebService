using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class BranchEmployeeResponseHandler : ResponseHandler, IRequestHandler<BranchEmployeeRequest, BranchEmployeeResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchEmployeeResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<BranchEmployeeResponse> Handle(BranchEmployeeRequest request)
    {
        var entity = _unitOfWork.GenericRepository<BranchEmployee>().Get();

        var result = BranchEmployeeResponse.FromEntity(entity);

        return Success(result);
    }
}

