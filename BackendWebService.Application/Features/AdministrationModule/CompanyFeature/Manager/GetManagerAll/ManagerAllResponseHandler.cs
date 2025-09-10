using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ManagerAllResponseHandler : ResponseHandler, IRequestHandler<ManagerAllRequest, List<ManagerAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ManagerAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ManagerAllResponse>> Handle(ManagerAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Manager>().GetAll();

        var result = entity.Select(ManagerAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

