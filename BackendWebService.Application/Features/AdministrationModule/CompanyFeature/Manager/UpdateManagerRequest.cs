using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateManagerRequest(
int OrganizationId,
string Name,
string Position,
List<UpdateManagerRequest> Manager);