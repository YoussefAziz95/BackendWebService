using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class DealDetailsResponseHandler : ResponseHandler, IRequestByIdHandler<DealDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealDetailsResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<DealDetailsResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<DealDetails>().GetById(id);

        var result = DealDetailsResponse.FromEntity(entity);

        return Success(result);
    }
}

