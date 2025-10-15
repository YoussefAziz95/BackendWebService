using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CompanyAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CompanyAllRequest, List<CompanyAllResponse>>
{
    public IResponse<List<CompanyAllResponse>> Handle(CompanyAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Company>().GetAll();

        var result = entity.Select(CompanyAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

