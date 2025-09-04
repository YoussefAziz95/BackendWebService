using Application.Profiles;
using Domain;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features;
public record UpdateProductRequest(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId,
UpdateCategoryRequest Category,
UpdateFileLogRequest? File):IConvertibleToEntity<Product>
{
public Product ToEntity() => new Product
{
Number = Number,
Name = Name,
Description = Description,
Code = Code,
PartNumber = PartNumber,
Manufacturer = Manufacturer,
FileId = FileId,
Category = Category.ToEntity(),
File = File.ToEntity()
};
}