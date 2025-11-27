

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteEmployeeCertificationRequest(int Id, string Password = null) : IRequest<string>;
