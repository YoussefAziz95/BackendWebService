using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record NotificationDetailRequest(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate) : IRequest<NotificationDetailResponse>
{
    public IValidator<NotificationDetailRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<NotificationDetailRequest> validator)
    {
        throw new NotImplementedException();
    }
}

