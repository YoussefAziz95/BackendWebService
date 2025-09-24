using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteFileTypeRequest(int Id, string Password = null) : IRequest<string>;
