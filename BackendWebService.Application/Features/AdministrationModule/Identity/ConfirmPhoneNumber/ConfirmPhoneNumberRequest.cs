using Application.Contracts.Features;

namespace Application.Features;
public record ConfirmPhoneNumberRequest(string PhoneNumber, string Code) : IRequest<int>;