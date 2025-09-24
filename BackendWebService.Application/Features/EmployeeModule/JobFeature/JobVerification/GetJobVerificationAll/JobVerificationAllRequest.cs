using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record JobVerificationAllRequest(
int EmployeeId,
VerificationEnum Verification,
string VerificationCode,
DateTime ExpirationTime,
bool IsVerified,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<JobVerificationAllResponse>>
{
    public IValidator<JobVerificationAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<JobVerificationAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

