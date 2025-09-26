using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record NotificationRequest(
string KeyMessageTitle,
string KeyMessageBody,
NotificationPriorityEnum Priority,
DateTime ExpiryDate,
int NotifierId,
int NotifiedId,
string NotifiedType,
int? NotificationTypeId,
string? NotificationType,
int? NotificationObjectId,
string? NotificationObjectType) : IRequest<NotificationResponse>
{
    public IValidator<NotificationRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<NotificationRequest> validator)
    {
        throw new NotImplementedException();
    }
}

