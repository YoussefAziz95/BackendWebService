using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class GetAllOrdersQueryHandler : ResponseHandler, IRequestHandler<GetAllOrdersQuery, List<GetAllOrdersQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<GetAllOrdersQueryResult>> Handle(GetAllOrdersQuery request)
    {
        var orders = _unitOfWork.GenericRepository<Order>().GetAll(include: o => o.Include(u => u.User));

        var result = orders.Select(c => new GetAllOrdersQueryResult(c.Id, c.OrderName, c.UserId, c.User.UserName)).ToList();

        return Success(result);
    }
}

