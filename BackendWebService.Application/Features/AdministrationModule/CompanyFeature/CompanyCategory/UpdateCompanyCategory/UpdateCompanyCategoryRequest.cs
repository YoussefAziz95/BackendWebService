using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateCompanyCategoryRequest(
int CompanyId,
int CategoryId) : IConvertibleToEntity<CompanyCategory>, IRequest<int>
{
    public CompanyCategory ToEntity() => new CompanyCategory
    {
        CompanyId = CompanyId,
        CategoryId = CategoryId
    };
}