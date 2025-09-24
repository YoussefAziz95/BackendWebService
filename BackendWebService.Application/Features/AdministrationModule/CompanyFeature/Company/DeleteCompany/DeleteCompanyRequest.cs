using Application.Contracts.Features;

namespace Application.Features;
public record DeleteCompanyRequest(int Id, string Password = null) : IRequest<string>;
