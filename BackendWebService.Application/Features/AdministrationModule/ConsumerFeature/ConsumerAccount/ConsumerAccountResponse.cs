using Application.Features;

namespace Application.Features;
public record ConsumerAccountResponse(
    int CompanyId,
    int ConsumerId,
    bool IsApproved,
    DateTime? ApprovedDate,
    List<ConsumerDocumentResponse> ConsumerDocument
);