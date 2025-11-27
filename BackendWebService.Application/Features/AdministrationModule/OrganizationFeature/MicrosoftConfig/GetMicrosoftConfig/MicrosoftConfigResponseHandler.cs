using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class MicrosoftConfigResponseHandler : ResponseHandler, IRequestByIdHandler<MicrosoftConfigResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public MicrosoftConfigResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<MicrosoftConfigResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<MicrosoftConfig>().GetById(id);

        var result = MicrosoftConfigResponse.FromEntity(entity);

        return Success(result);
    }
}

