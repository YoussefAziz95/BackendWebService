using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchWorkingHourAllResponse(
int BranchId,
DayOfWeek DayOfWeek,
TimeSpan OpenTime,
TimeSpan CloseTime,
bool IsClosed): IConvertibleFromEntity<BranchWorkingHour, BranchWorkingHourAllResponse>        
{
public static BranchWorkingHourAllResponse FromEntity(BranchWorkingHour BranchWorkingHour) =>
new BranchWorkingHourAllResponse(
BranchWorkingHour.BranchId,
BranchWorkingHour.DayOfWeek,
BranchWorkingHour.OpenTime,
BranchWorkingHour.CloseTime,
BranchWorkingHour.IsClosed);
}
