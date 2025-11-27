using Application.Contracts.Features;

namespace Application.Features;
public record DeleteTransactionRequest(int Id, string Password = null) : IRequest<string>;
