using Application.Profiles;
using Domain;

namespace Application.Features;
public record UpdateBranchWorkingHourRequest(
int BranchId,
DayOfWeek DayOfWeek,
TimeSpan OpenTime,
TimeSpan CloseTime,
bool IsClosed):IConvertibleToEntity<BranchWorkingHour>
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
    