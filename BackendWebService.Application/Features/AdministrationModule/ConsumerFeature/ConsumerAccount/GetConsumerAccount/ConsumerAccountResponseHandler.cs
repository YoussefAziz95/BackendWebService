using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ConsumerAccountResponseHandler : ResponseHandler, IRequestHandler<ConsumerAccountRequest, ConsumerAccountResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerAccountResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ConsumerAccountResponse> Handle(ConsumerAccountRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ConsumerAccount>().Get();

        var result = ConsumerAccountResponse.FromEntity(entity);

        return Success(result);
    }
}

