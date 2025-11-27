using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class DepartmentAllResponseHandler : ResponseHandler, IRequestHandler<DepartmentAllRequest, List<DepartmentAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<DepartmentAllResponse>> Handle(DepartmentAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Department>().GetAll();

        var result = entity.Select(DepartmentAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

