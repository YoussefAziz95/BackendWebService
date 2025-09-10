using BackendWebService.Application.Features.ClientModule.Deals.GetOfferDealDetails;

namespace Application.Features;

public record GetOfferDealResponse(
int OfferId,
string OfferName,
List<GetOfferDealDocumentResponse> DealDocuments,
List<GetOfferDealDetailsResponse> DealDetails);
