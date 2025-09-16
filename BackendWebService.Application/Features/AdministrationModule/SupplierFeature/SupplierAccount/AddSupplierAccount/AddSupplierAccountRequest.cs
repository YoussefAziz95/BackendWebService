using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;

namespace Application.Features;

public record AddSupplierAccountRequest(
int CompanyId,
int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<AddSupplierDocumentRequest> SupplierDocuments) : IConvertibleToEntity<SupplierAccount>,IRequest<int>
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

