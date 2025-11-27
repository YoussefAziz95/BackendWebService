using Application.Contracts.Features;
using Microsoft.AspNetCore.Identity;

namespace Application.Features;

public class CustomIdentityResult : IdentityResult, IRequest<int>
{
}
