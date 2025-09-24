using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class PartResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PartRequest, PartResponse>
{

    public IResponse<PartResponse> Handle(PartRequest request)
    {
        var entity = unitOfWork.GenericRepository<Part>().Get();

        var result = PartResponse.FromEntity(entity);

        return Success(result);
    }
}