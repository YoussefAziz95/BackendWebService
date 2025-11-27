using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ConsumerResponseHandler : ResponseHandler, IRequestByIdHandler<ConsumerResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ConsumerResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Consumer>().GetById(id);

        var result = ConsumerResponse.FromEntity(entity);

        return Success(result);
    }
}

