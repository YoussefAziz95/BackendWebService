using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddBranchWorkingHourRequest(
int BranchId,
DayOfWeek DayOfWeek,
TimeSpan OpenTime,
TimeSpan CloseTime,
bool IsClosed) : IConvertibleToEntity<BranchWorkingHour>,IRequest<int>
{
    public BranchWorkingHour ToEntity() => new BranchWorkingHour
    {
        BranchId = BranchId,
        DayOfWeek = DayOfWeek,
        OpenTime = OpenTime,
        CloseTime = CloseTime,
        IsClosed = IsClosed
    };
}