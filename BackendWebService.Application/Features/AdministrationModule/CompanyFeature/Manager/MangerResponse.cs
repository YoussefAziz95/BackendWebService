namespace Application.Features;
public record ManagerResponse(
   int OrganizationId,
    string Name,
    string Position,
    List<ManagerResponse> Manager
);