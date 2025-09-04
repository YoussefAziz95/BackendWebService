using Application.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record ProductResponse(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId,
CategoryResponse Category,
FileLogResponse? File):IConvertibleFromEntity<Product, ProductResponse>
{
public static ProductResponse FromEntity(Product Product) =>
new ProductResponse(
Product.Number,
Product.Name,
Product.Description,
Product.Code,
Product.PartNumber,
Product.Manufacturer,
Product.FileId,
Product.Category.ToEntity(),
Product.File.ToEntity());
}