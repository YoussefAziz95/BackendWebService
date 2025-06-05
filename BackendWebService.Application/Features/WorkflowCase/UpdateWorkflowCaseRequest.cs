using Domain.Enums;

namespace Application.Features;

public record UpdateWorkflowCaseRequest(StatusEnum Status, string Comment);