using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ZoneResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<ZoneResponse>
{

    public IResponse<ZoneResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Zone>().GetById(id);

        var result = ZoneResponse.FromEntity(entity);

        return Success(result);
    }
}