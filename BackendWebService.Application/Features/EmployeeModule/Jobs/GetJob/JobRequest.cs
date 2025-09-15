using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record JobRequest(
string Name,
string? Description,
DateTime StartDate,
DateTime EndDate,
DateTime? ExpirationTime,
bool IsVerified) : IRequest<JobResponse>
{
public IValidator<JobRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<JobRequest> validator)
{
throw new NotImplementedException();
}
}

