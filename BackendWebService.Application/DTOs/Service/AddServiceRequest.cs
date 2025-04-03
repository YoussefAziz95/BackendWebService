using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;
namespace Application.DTOs.Services
{
    public class AddServiceRequest : BaseValidationModel<AddServiceRequest>, ICreateMapper<Service>
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
    }
}
