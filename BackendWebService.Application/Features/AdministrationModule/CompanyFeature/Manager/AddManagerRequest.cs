namespace Application.Features;
public record AddManagerRequest(
    int CompanyId,
    string Name,
    string Position
);
