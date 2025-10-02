using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class SparePartResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<SparePartResponse>
{

    public IResponse<SparePartResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<SparePart>().GetById(id);

        var result = SparePartResponse.FromEntity(entity);

        return Success(result);
    }
}