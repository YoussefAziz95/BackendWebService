namespace Application.Features;
public record ContactResponse(
    int Id,
    string Type,
    string? Value
);