using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CompanyCategoryAllResponseHandler : ResponseHandler, IRequestHandler<CompanyCategoryAllRequest, List<CompanyCategoryAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompanyCategoryAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<CompanyCategoryAllResponse>> Handle(CompanyCategoryAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<CompanyCategory>().GetAll();

        var result = entity.Select(CompanyCategoryAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

