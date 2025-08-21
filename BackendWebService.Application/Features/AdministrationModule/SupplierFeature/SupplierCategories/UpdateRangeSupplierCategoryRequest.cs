namespace Application.Features;
public record UpdateRangeSupplierCategoryRequest(
    int Id,
    int CompanyId,
    int CategoryId,
    bool IsDeleted
    );