

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteOfferItemRequest(int Id, string Password = null) : IRequest<string>;
