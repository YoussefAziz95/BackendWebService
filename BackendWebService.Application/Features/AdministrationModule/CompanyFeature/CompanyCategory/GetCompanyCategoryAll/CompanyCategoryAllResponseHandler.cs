using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CompanyCategoryAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CompanyCategoryAllRequest, List<CompanyCategoryAllResponse>>
{

    public IResponse<List<CompanyCategoryAllResponse>> Handle(CompanyCategoryAllRequest request)
    {
        var entities = unitOfWork.GenericRepository<CompanyCategory>().GetAll();

        var result = entities.Select(CompanyCategoryAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

