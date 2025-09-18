using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class PortionItemAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PortionItemAllRequest, List<PortionItemAllResponse>>
{
    public IResponse<List<PortionItemAllResponse>> Handle(PortionItemAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<PortionItem>().GetAll();

        var result = entity.Select(PortionItemAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

