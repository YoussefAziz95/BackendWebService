using Domain.Enums;

namespace Application.Features;

public record UserPagesResponse(int Id, string? Groups, string? Menu, string? Page, string? Permission, string? Value);