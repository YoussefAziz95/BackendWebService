

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteReceiptRequest(int Id, string Password = null) : IRequest<string>;
