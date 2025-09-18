using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class PortionItemResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PortionItemRequest, PortionItemResponse>
{
 
    public IResponse<PortionItemResponse> Handle(PortionItemRequest request)
    {
        var entity = unitOfWork.GenericRepository<PortionItem>().Get();

        var result = PortionItemResponse.FromEntity(entity);

        return Success(result);
    }
}