using Application.Contracts.Features;

namespace Application.Features;
public record DeleteTranslationKeyRequest(int Id, string Password = null) : IRequest<string>;
