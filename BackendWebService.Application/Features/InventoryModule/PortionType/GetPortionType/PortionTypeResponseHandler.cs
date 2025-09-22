using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class PortionTypeResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PortionTypeRequest, PortionTypeResponse>
{
 
    public IResponse<PortionTypeResponse> Handle(PortionTypeRequest request)
    {
        var entity = unitOfWork.GenericRepository<PortionType>().Get();

        var result = PortionTypeResponse.FromEntity(entity);

        return Success(result);
    }
}