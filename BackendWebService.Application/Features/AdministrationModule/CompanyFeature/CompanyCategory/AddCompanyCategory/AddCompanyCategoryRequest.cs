using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AddCompanyCategoryRequest(
int CompanyId,
int CategoryId) : IConvertibleToEntity<CompanyCategory> , IRequest<int>
{
    public CompanyCategory ToEntity() => new CompanyCategory
    {
        CompanyId = CompanyId,
        CategoryId = CategoryId
    };
}