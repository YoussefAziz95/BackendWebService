using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record TimeSlotAllRequest(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<TimeSlotAllResponse>>
{
    public IValidator<TimeSlotAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<TimeSlotAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

