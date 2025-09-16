using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ConsumerCustomerAllResponseHandler : ResponseHandler, IRequestHandler<ConsumerCustomerAllRequest, List<ConsumerCustomerAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerCustomerAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ConsumerCustomerAllResponse>> Handle(ConsumerCustomerAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ConsumerCustomer>().GetAll();

        var result = entity.Select(ConsumerCustomerAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

