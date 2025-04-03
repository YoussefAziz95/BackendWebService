using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using System.ComponentModel.DataAnnotations;

using Domain.Enums;
using Domain;
namespace Application.DTOs.Services
{
    public class UpdateServiceRequest : BaseValidationModel<UpdateServiceRequest>, ICreateMapper<Service>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
    }
}
