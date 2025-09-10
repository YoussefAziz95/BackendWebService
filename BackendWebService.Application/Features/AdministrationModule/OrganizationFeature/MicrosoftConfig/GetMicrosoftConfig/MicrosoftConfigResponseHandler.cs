using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class MicrosoftConfigResponseHandler : ResponseHandler, IRequestHandler<MicrosoftConfigRequest, MicrosoftConfigResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public MicrosoftConfigResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<MicrosoftConfigResponse> Handle(MicrosoftConfigRequest request)
    {
        var entity = _unitOfWork.GenericRepository<MicrosoftConfig>().Get();

        var result = MicrosoftConfigResponse.FromEntity(entity);

        return Success(result);
    }
}

