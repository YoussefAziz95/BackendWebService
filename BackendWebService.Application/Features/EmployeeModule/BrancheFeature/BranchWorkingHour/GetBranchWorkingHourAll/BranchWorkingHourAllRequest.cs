using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchWorkingHourAllRequest(
int BranchId,
DayOfWeek DayOfWeek,
TimeSpan OpenTime,
TimeSpan CloseTime,
bool IsClosed,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<BranchWorkingHourAllResponse>>
{
    public IValidator<BranchWorkingHourAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchWorkingHourAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

