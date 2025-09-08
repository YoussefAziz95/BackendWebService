using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class CompanyCategoryResponseHandler : ResponseHandler, IRequestHandler<CompanyCategoryRequest, CompanyCategoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompanyCategoryResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CompanyResponse> Handle(CompanyRequest request)
    {
        var orders = _unitOfWork.GenericRepository<Company>().Get();

        var result = CompanyResponse.FromEntity(orders);

        return Success(result);
    }
}

