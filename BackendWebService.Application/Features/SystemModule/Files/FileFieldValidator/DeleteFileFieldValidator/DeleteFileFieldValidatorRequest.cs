using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteFileFieldValidatorRequest(int Id, string Password = null) : IRequest<string>;
