using Application.Profiles;
using Domain;
using System.ComponentModel.Design;

namespace Application.Features;
public record AddCompanyCategoryRequest(
int CompanyId,
int CategoryId): IConvertibleToEntity<CompanyCategory>
{
public CompanyCategory ToEntity() => new CompanyCategory
{
CompanyId = CompanyId,
CategoryId = CategoryId
};
}