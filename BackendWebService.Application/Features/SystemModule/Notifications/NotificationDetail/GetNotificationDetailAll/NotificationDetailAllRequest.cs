using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record NotificationDetailAllRequest(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<NotificationDetailAllResponse>>
{
    public IValidator<NotificationDetailAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<NotificationDetailAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

