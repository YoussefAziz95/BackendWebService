using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeCertificationAllRequest(
int EmployeeId,
string CertificationName,
string IssuingAuthority,
DateTime IssuedDate,
DateTime? ExpirationDate,
StatusEnum Status,
string? VerificationNotes,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<EmployeeCertificationAllResponse>>
{
    public IValidator<EmployeeCertificationAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeCertificationAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

