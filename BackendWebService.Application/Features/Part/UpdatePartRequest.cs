namespace Application.Features;

public record UpdatePartRequest(int Id, string Name, string Description, string Code, string Image, string PartNumber, string Manufacturer, int ProductId);