using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class ZoneResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ZoneRequest, ZoneResponse>
{
 
    public IResponse<ZoneResponse> Handle(ZoneRequest request)
    {
        var entity = unitOfWork.GenericRepository<Zone>().Get();

        var result = ZoneResponse.FromEntity(entity);

        return Success(result);
    }
}