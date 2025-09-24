using Application.Contracts.Features;

namespace Application.Features;
public record DeleteCompanyCategoryRequest(int Id, string Password = null) : IRequest<string>;
