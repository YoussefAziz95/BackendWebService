using Domain;
using Domain.Enums;

namespace Application.Features;
public record CaseAllResponse(
int ActionIndex,
int WorkflowId,
Workflow Workflow,
int StatusId,
int? CompanySupplierId,
ConsumerAccount? CompanySupplier,
int? UserId,
 User? User);

