using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class GoogleConfigResponseHandler : ResponseHandler, IRequestByIdHandler<GoogleConfigResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GoogleConfigResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<GoogleConfigResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<GoogleConfig>().GetById(id);

        var result = GoogleConfigResponse.FromEntity(entity);

        return Success(result);
    }
}

