using Application.Profiles;
using Domain;

namespace Application.Features;
public record UpdateSpareRequest(
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId,
UpdateProductRequest Product):IConvertibleToEntity<Spare>
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