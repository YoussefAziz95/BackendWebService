using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CompanyAllResponseHandler : ResponseHandler, IRequestHandler<CompanyAllRequest, List<CompanyAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompanyAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<CompanyAllResponse>> Handle(CompanyAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Company>().GetAll();

        var result = entity.Select(CompanyAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

