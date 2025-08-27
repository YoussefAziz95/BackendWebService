using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateCaseActionRequest(
int? Order,
int? WorkflowActorId,
User? WorkflowActor,
int CaseId,
Case Case,
int WorkflowCycleId,
WorkflowCycle WorkflowCycle,
int StatusId);