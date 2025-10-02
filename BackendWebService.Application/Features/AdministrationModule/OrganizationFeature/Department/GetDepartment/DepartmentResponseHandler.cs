using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class DepartmentResponseHandler : ResponseHandler, IRequestByIdHandler<DepartmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<DepartmentResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Department>().GetById(id);

        var result = DepartmentResponse.FromEntity(entity);

        return Success(result);
    }
}

