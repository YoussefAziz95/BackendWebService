using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateCaseRequest(
int ActionIndex,
int WorkflowId,
Workflow Workflow,
int StatusId,
int? CompanySupplierId,
ConsumerAccount?CompanySupplier,
int? UserId,
User? User,
List<UpdateCaseActionRequest> CaseActions);