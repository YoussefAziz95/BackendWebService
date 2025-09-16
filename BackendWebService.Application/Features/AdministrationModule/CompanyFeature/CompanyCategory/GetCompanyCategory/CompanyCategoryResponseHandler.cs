using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CompanyCategoryResponseHandler : ResponseHandler, IRequestHandler<CompanyCategoryRequest, CompanyCategoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompanyCategoryResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CompanyCategoryResponse> Handle(CompanyCategoryRequest request)
    {
        var entity = _unitOfWork.GenericRepository<CompanyCategory>().Get();

        var result = CompanyCategoryResponse.FromEntity(entity);

        return Success<CompanyCategoryResponse>(result);
    }
}

