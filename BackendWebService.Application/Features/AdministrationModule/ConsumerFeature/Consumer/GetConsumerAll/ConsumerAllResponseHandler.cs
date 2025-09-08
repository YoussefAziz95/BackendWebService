using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ConsumerAllResponseHandler : ResponseHandler, IRequestHandler<ConsumerAllRequest, List<ConsumerAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ConsumerAllResponse>> Handle(ConsumerAllRequest request)
    {
        var orders = _unitOfWork.GenericRepository<Consumer>().GetAll();

        var result = orders.Select(ConsumerAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

