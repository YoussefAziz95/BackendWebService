using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class CompanyResponseHandler : ResponseHandler, IRequestHandler<CompanyRequest, CompanyResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompanyResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<CompanyResponse> Handle(CompanyRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Company>().Get();

        var result = CompanyResponse.FromEntity(entity);

        return Success(result);
    }
}

