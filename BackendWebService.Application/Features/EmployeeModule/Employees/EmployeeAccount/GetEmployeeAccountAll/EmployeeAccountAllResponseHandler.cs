using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class EmployeeAccountAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeAccountAllRequest, List<EmployeeAccountAllResponse>>
{
    public IResponse<List<EmployeeAccountAllResponse>> Handle(EmployeeAccountAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeAccount>().GetAll();

        var result = entity.Select(EmployeeAccountAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

