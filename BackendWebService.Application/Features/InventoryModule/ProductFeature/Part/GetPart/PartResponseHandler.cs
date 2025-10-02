using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PartResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<PartResponse>
{

    public IResponse<PartResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Part>().GetById(id);

        var result = PartResponse.FromEntity(entity);

        return Success(result);
    }
}