using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace BackendWebService.Application.Features.CustomerModule.Orders.OrderCQRS.GetUserOrders;
internal class GetUserOrdersQueryHandler : ResponseHandler, IRequestHandler<GetUserOrdersQuery, List<GetUserOrdersQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserOrdersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<GetUserOrdersQueryResult>> Handle(GetUserOrdersQuery request)
    {
        var entity = _unitOfWork.GenericRepository<Order>().GetAll(o => o.UserId == request.UserId);

        if (entity.Any())
            return NotFound<List<GetUserOrdersQueryResult>>("You Don't Have Any Orders");

        var result = entity.Select(c => new GetUserOrdersQueryResult(c.Id, c.OrderName));

        return Success(result.ToList());
    }
}