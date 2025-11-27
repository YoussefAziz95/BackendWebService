

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteOfferObjectRequest(int Id, string Password = null) : IRequest<string>;
