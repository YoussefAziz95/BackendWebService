using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record GetPaginatedSupplier(
  int OrganizationId,
 decimal? Rating,
 string? BankAccount,
 StatusEnum Status,
 List<AddSupplierCategoryRequest> SupplierCategories
    );