using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class GoogleConfigResponseHandler : ResponseHandler, IRequestHandler<GoogleConfigRequest, GoogleConfigResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GoogleConfigResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<GoogleConfigResponse> Handle(GoogleConfigRequest request)
    {
        var entity = _unitOfWork.GenericRepository<GoogleConfig>().Get();

        var result = GoogleConfigResponse.FromEntity(entity);

        return Success(result);
    }
}

