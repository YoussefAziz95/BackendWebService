namespace Application.Features;
public record AddConsumerAccountRequest(
    int CompanyId,
    int ConsumerId,
    bool IsApproved,
    DateTime? ApprovedDate,
    List<AddConsumerDocumentRequest> ConsumerDocument
);
