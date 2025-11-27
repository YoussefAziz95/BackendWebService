using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ConsumerCustomerResponseHandler : ResponseHandler, IRequestByIdHandler<ConsumerCustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerCustomerResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ConsumerCustomerResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<ConsumerCustomer>().GetById(id);

        var result = ConsumerCustomerResponse.FromEntity(entity);

        return Success(result);
    }
}

