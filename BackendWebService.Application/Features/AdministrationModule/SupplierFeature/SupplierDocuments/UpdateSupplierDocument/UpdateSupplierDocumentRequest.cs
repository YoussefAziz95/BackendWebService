using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateSupplierDocumentRequest(
int SupplierAccountId,
int PreDocumentId,
int FileId,
DateTime? ApprovedDate,
bool IsApproved,
string? Comment,
UpdatePreDocumentRequest PreDocument,
UpdateSupplierAccountRequest SupplierAccount) : IConvertibleToEntity<SupplierDocument>, IRequest<int>
{
    public SupplierDocument ToEntity() => new SupplierDocument
    {
        SupplierAccountId = SupplierAccountId,
        PreDocumentId = PreDocumentId,
        FileId = FileId,
        ApprovedDate = ApprovedDate,
        IsApproved = IsApproved,
        Comment = Comment,
        PreDocument = PreDocument.ToEntity(),
        SupplierAccount = SupplierAccount.ToEntity()
    };
}