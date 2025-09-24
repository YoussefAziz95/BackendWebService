using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ConsumerCustomerResponseHandler : ResponseHandler, IRequestHandler<ConsumerCustomerRequest, ConsumerCustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerCustomerResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ConsumerCustomerResponse> Handle(ConsumerCustomerRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ConsumerCustomer>().Get();

        var result = ConsumerCustomerResponse.FromEntity(entity);

        return Success(result);
    }
}

