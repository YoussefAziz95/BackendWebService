using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class DealDetailsResponseHandler : ResponseHandler, IRequestHandler<DealDetailsRequest, DealDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealDetailsResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<DealDetailsResponse> Handle(DealDetailsRequest request)
    {
        var entity = _unitOfWork.GenericRepository<DealDetails>().Get();

        var result = DealDetailsResponse.FromEntity(entity);

        return Success(result);
    }
}

