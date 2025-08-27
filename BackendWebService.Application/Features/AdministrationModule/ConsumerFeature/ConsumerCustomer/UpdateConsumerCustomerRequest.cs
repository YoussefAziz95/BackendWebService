using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateConsumerCustomerRequest(
int SupplierId,
int CategoryId);