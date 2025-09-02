using Domain;

namespace BackendWebService.Application.Features.InventoryModule.Products.Part;
public record UpdatePartRequest(
    int id,
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId,
Product Product);