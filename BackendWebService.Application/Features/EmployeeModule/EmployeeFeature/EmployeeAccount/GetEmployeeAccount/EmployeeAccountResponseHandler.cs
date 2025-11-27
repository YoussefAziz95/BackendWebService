using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class EmployeeAccountResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<EmployeeAccountResponse>
{

    public IResponse<EmployeeAccountResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<EmployeeAccount>().GetById(id);

        var result = EmployeeAccountResponse.FromEntity(entity);

        return Success(result);
    }
}