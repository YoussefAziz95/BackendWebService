using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdateSupplierRequest(
 int OrganizationId,
 decimal? Rating,
 string? BankAccount,
 StatusEnum Status,
 List<AddSupplierCategoryRequest> SupplierCategories
    );