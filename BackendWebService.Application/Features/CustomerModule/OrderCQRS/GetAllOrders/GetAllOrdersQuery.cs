using Application.Contracts.Features;

namespace Application.Features;
public record GetAllOrdersQuery() : IRequest<List<GetAllOrdersQueryResult>>;