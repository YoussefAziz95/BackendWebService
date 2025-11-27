using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record NotificationAllRequest(
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
string? NotificationObjectType,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<NotificationAllResponse>>
{
    public IValidator<NotificationAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<NotificationAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

