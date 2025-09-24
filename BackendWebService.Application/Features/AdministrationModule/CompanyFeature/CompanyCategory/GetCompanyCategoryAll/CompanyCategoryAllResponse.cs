using Application.Profiles;
using Domain;

namespace Application.Features;

public record CompanyCategoryAllResponse(
int CompanyId,
int CategoryId) : IConvertibleFromEntity<CompanyCategory, CompanyCategoryAllResponse>
{
    public static CompanyCategoryAllResponse FromEntity(CompanyCategory companyCategory) =>
    new CompanyCategoryAllResponse(
    companyCategory.CompanyId,
    companyCategory.CategoryId);
}