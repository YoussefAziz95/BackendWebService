using Application.Profiles;
using Domain;

namespace Application.Features;
public record CompanyCategoryResponse(
  int CompanyId,
   int CategoryId
  
) : IConvertibleFromEntity<CompanyCategory, CompanyCategoryResponse>
{
    public static CompanyCategoryResponse FromEntity(CompanyCategory companyCategory) =>
        new CompanyCategoryResponse(
            companyCategory.CategoryId,
            companyCategory.CompanyId);
}