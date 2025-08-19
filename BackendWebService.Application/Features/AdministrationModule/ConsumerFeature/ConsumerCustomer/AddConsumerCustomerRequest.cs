namespace Application.Features;
public record AddConsumerCustomerRequest(
    int SupplierId,
    int CategoryId
);
