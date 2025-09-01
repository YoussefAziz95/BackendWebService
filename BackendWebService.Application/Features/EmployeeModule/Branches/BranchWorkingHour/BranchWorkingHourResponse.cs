using Application.Profiles;
using Domain;

namespace Application.Features;
public record BranchWorkingHourResponse(
int BranchId,
DayOfWeek DayOfWeek,
TimeSpan OpenTime,
TimeSpan CloseTime,
bool IsClosed): IConvertibleFromEntity<BranchWorkingHour, BranchWorkingHourResponse>        
{
public static BranchWorkingHourResponse FromEntity(BranchWorkingHour BranchWorkingHour) =>
new BranchWorkingHourResponse(
BranchWorkingHour.BranchId,
BranchWorkingHour.DayOfWeek,
BranchWorkingHour.OpenTime,
BranchWorkingHour.CloseTime,
BranchWorkingHour.IsClosed);
}