using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class DepartmentResponseHandler : ResponseHandler, IRequestHandler<DepartmentRequest, DepartmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<DepartmentResponse> Handle(DepartmentRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Department>().Get();

        var result = DepartmentResponse.FromEntity(entity);

        return Success(result);
    }
}

