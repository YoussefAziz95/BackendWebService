using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class EmployeeJobResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<EmployeeJobResponse>
{

    public IResponse<EmployeeJobResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<EmployeeJob>().GetById(id);

        var result = EmployeeJobResponse.FromEntity(entity);

        return Success(result);
    }
}