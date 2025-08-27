using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateCompanyCategoryRequest(
 int CompanyId,
 int CategoryId);