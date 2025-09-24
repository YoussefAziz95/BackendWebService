using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class EmployeeJobAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeJobAllRequest, List<EmployeeJobAllResponse>>
{
    public IResponse<List<EmployeeJobAllResponse>> Handle(EmployeeJobAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeJob>().GetAll();

        var result = entity.Select(EmployeeJobAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

