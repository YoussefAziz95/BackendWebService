using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddSpareRequest(
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId,
AddProductRequest Product) : IConvertibleToEntity<Spare>, IRequest<int>
{
    public Spare ToEntity() => new Spare
    {
        IsAvailable = IsAvailable,
        RequiredAmount = RequiredAmount,
        AvailableAmount = AvailableAmount,
        ProductId = ProductId,
        Product = Product.ToEntity()

    };
}