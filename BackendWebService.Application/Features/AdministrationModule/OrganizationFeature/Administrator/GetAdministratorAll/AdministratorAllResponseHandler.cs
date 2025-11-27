using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class AdministratorAllResponseHandler : ResponseHandler, IRequestHandler<AdministratorAllRequest, List<AdministratorAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AdministratorAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<AdministratorAllResponse>> Handle(AdministratorAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Administrator>().GetAll();

        var result = entity.Select(AdministratorAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

