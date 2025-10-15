using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PortionItemResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<PortionItemResponse>
{

    public IResponse<PortionItemResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<PortionItem>().GetById(id);

        var result = PortionItemResponse.FromEntity(entity);

        return Success(result);
    }
}