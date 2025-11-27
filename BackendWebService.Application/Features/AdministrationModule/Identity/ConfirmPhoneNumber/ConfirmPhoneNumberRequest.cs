using Application.Contracts.Features;
using Microsoft.AspNetCore.Identity;

namespace Application.Features;
public record ConfirmPhoneNumberRequest(string PhoneNumber, string Code) : IRequest<IdentityResult>;