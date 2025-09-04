using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ProductAllResponse(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId) : IConvertibleFromEntity<Product, ProductAllResponse>
{
public static ProductAllResponse FromEntity(Product Product) =>
new ProductAllResponse(
Product.Number,
Product.Name,
Product.Description,
Product.Code,
Product.PartNumber,
Product.Manufacturer,
Product.FileId);
}

