using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class ConsumerResponseHandler : ResponseHandler, IRequestHandler<ConsumerRequest, ConsumerResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ConsumerResponse> Handle(ConsumerRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Consumer>().Get();

        var result = ConsumerResponse.FromEntity(entity);

        return Success(result);
    }
}

