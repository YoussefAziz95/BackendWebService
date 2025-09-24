using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class SpareAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<SpareAllRequest, List<SpareAllResponse>>
{
    public IResponse<List<SpareAllResponse>> Handle(SpareAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Spare>().GetAll();

        var result = entity.Select(SpareAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

