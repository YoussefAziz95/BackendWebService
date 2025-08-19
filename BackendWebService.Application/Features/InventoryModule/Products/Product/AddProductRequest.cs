namespace Application.Features;
public record AddProductRequest(string Number, string Name, string Description, int? FileId, string Code, string PartNumber, string Manufacturer, int CategoryId);