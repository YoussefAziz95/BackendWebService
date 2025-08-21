namespace Application.Features;
public record AddManagerRequest(
    int OrganizationId,
    string Name,
    string Position,
    List<AddManagerRequest> Manager
);
