using Application.Contracts.Features;

namespace Application.Features;

public record GetUserOrdersQuery(int UserId) : IRequest<List<GetUserOrdersQueryResult>>;