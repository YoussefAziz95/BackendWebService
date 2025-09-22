using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

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
FileLogResponse? File) : IConvertibleFromEntity<Product, ProductResponse>
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
    CategoryResponse.FromEntity(Product.Category),
    FileLogResponse.FromEntity(Product.File));
}