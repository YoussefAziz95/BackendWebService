using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateMangerRequest(
 int OrganizationId,
    string Name,
    string Position,
    List<AddManagerRequest> Manager
    );