using Application.Contracts.Features;
using Application.Profiles;
namespace Application.Features;
public record UpdateSupplierAccountRequest(
int CompanyId,
int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<UpdateSupplierDocumentRequest> SupplierDocuments) : IConvertibleToEntity<SupplierAccount>, IRequest<int>
{
    public SupplierAccount ToEntity() => new SupplierAccount
    {
        CompanyId = CompanyId,
        SupplierId = SupplierId,
        IsApproved = IsApproved,
        ApprovedDate = ApprovedDate,
        SupplierDocuments = SupplierDocuments.Select(x => x.ToEntity()).ToList()
    };
}
