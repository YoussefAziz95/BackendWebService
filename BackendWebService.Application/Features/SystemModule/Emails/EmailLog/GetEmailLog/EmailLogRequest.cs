using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmailLogRequest(
string Subject,
string Body,
DateTime SentAt,
int SenderId) : IRequest<EmailLogResponse>
{
    public IValidator<EmailLogRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmailLogRequest> validator)
    {
        throw new NotImplementedException();
    }
}

