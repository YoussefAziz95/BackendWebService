using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmailLogAllRequest(
string Subject,
string Body,
DateTime SentAt,
int SenderId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<EmailLogAllResponse>>
{
    public IValidator<EmailLogAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmailLogAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

