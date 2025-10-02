using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class GoogleConfigAllResponseHandler : ResponseHandler, IRequestHandler<GoogleConfigAllRequest, List<GoogleConfigAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GoogleConfigAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<GoogleConfigAllResponse>> Handle(GoogleConfigAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<GoogleConfig>().GetAll();

        var result = entity.Select(GoogleConfigAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

