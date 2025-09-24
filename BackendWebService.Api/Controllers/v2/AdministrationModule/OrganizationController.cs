using Api.Base;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
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
