namespace BackendWebService.Application.Features.InventoryModule.Products.Part;
public record AddPartRequest(
    string Name,
    string Description,
    string Code,
    string Image,
    string PartNumber,
    string Manufacturer,
    int ProductId);