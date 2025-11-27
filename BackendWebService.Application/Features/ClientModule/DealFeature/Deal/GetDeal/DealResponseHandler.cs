using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class DealResponseHandler : ResponseHandler, IRequestByIdHandler<DealResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<DealResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Deal>().GetById(id);

        var result = DealResponse.FromEntity(entity);

        return Success(result);
    }
}

