namespace Application.Features;
public record AddContactRequest(
    int CompanyId,
    string? Value,
    string Type
);
