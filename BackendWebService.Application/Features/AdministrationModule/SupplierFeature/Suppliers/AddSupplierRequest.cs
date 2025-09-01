using Application.Profiles;
using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddSupplierRequest(
 int OrganizationId,
 decimal? Rating,
 string? BankAccount,
 StatusEnum Status,
 List<AddSupplierCategoryRequest> SupplierCategories):IConvertibleToEntity<Supplier>
{
public Supplier ToEntity() => new Supplier
{
    OrganizationId = OrganizationId,
    Rating = Rating,
    BankAccount = BankAccount,
    Status = Status,
    SupplierCategories = SupplierCategories.Select(x => x.ToEntity()).ToList()
};
}