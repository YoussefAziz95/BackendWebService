using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ConsumerAccountResponseHandler : ResponseHandler, IRequestByIdHandler<ConsumerAccountResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerAccountResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ConsumerAccountResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<ConsumerAccount>().GetById(id);

        var result = ConsumerAccountResponse.FromEntity(entity);

        return Success(result);
    }
}

