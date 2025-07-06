namespace Application.Features;
public record AddCriteriaRequest(
    string Term,
    int FileTypeId,
    bool? IsRequired,
    int Weight,
    int OfferId
);
