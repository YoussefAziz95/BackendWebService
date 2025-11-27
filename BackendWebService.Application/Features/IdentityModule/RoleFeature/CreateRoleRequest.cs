namespace Application.Features;
public record CreateRoleRequest(string Name, List<string> Claims);