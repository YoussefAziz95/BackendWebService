using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class PortionResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PortionRequest, PortionResponse>
{
 
    public IResponse<PortionResponse> Handle(PortionRequest request)
    {
        var entity = unitOfWork.GenericRepository<Portion>().Get();

        var result = PortionResponse.FromEntity(entity);

        return Success(result);
    }
}