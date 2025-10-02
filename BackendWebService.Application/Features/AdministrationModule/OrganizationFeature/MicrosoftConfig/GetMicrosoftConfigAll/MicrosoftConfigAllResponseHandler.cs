using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class MicrosoftConfigAllResponseHandler : ResponseHandler, IRequestHandler<MicrosoftConfigAllRequest, List<MicrosoftConfigAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public MicrosoftConfigAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<MicrosoftConfigAllResponse>> Handle(MicrosoftConfigAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<MicrosoftConfig>().GetAll();

        var result = entity.Select(MicrosoftConfigAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

