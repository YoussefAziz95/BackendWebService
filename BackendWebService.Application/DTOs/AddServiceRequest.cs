namespace Application.DTOs;
public record AddServiceRequest(string Name, string Code, string CategoryName);
public record ServiceResponse(int Id, string Name, string Code, string CategoryName);
public record UpdateServiceRequest(int Id, string Name, string Code);
public record GetPaginatedService(int Id, string Name, string Code);
