

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteTimeSlotRequest(int Id, string Password = null) : IRequest<string>;
