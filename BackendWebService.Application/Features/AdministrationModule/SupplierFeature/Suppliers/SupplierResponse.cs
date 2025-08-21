using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record SupplierResponse(
 int OrganizationId,
 decimal? Rating,
 string? BankAccount,
 StatusEnum Status,
 List<AddSupplierCategoryRequest> SupplierCategories
    );