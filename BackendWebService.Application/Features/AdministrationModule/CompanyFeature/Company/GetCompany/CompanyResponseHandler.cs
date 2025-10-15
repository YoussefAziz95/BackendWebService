using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CompanyResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<CompanyResponse>
{
    public IResponse<CompanyResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Company>().GetById(id);

        var result = CompanyResponse.FromEntity(entity);

        return Success(result);
    }
}

