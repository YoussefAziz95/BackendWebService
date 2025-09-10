using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ConsumerAccountAllResponseHandler : ResponseHandler, IRequestHandler<ConsumerAccountAllRequest, List<ConsumerAccountAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerAccountAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ConsumerAccountAllResponse>> Handle(ConsumerAccountAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ConsumerAccount>().GetAll();

        var result = entity.Select(ConsumerAccountAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

