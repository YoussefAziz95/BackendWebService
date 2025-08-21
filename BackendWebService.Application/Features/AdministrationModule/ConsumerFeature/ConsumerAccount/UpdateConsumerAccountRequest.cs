using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateConsumerAccountRequest(
   int CompanyId,
    int ConsumerId,
    bool IsApproved,
    DateTime? ApprovedDate,
    List<AddConsumerDocumentRequest> ConsumerDocument
    );