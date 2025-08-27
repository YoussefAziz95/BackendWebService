using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddCaseActionRequest(
int? Order,
int? WorkflowActorId,
User? WorkflowActor,
int CaseId,
Case Case,
int WorkflowCycleId,
WorkflowCycle WorkflowCycle,
int StatusId);