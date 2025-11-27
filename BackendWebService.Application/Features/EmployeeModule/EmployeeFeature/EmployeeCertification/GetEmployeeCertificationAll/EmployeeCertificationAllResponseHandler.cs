using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class EmployeeCertificationAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeCertificationAllRequest, List<EmployeeCertificationAllResponse>>
{
    public IResponse<List<EmployeeCertificationAllResponse>> Handle(EmployeeCertificationAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeCertification>().GetAll();

        var result = entity.Select(EmployeeCertificationAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

