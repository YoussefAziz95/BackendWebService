using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class EmployeeCertificationResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<EmployeeCertificationResponse>
{

    public IResponse<EmployeeCertificationResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<EmployeeCertification>().GetById(id);

        var result = EmployeeCertificationResponse.FromEntity(entity);

        return Success(result);
    }
}