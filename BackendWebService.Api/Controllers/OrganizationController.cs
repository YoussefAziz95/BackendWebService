using Application.Contracts.Services;
using Application.Implementations;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Base;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : AppControllerBase
    {
        public readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
            
        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetOrgName([FromRoute] int id)
        {
            var result = await _organizationService.OrganizationNameById(id);
            return Ok(result);
        }
    }
}
