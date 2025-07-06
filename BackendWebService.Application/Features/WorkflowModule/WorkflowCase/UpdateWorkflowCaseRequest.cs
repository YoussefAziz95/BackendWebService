using Domain.Enums;

namespace Application.Features;
public record UpdateCaseRequest(StatusEnum Status, string Comment);