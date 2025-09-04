using Application.Profiles;
using Domain;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Features;
public record UpdatePartRequest(
int id,
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId,
UpdateProductRequest Product):IConvertibleToEntity<Part>
{
public Part ToEntity() => new Part
{
Name = Name,
Description = Description,
Code = Code,
Image = Image,
PartNumber = PartNumber,
Manufacturer = Manufacturer,
ProductId = ProductId,
Product = Product.ToEntity()

};
}