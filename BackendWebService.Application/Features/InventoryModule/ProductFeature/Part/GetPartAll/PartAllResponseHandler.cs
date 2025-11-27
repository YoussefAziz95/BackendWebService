using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PartAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PartAllRequest, List<PartAllResponse>>
{
    public IResponse<List<PartAllResponse>> Handle(PartAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Part>().GetAll();

        var result = entity.Select(PartAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

