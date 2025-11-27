

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteBranchWorkingHourRequest(int Id, string Password = null) : IRequest<string>;
