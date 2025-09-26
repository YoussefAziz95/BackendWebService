using Api.Base;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;


[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class OrganizationController : AppControllerBase
{
    public readonly IOrganizationService _organizationService;
    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;

    }

    [HttpGet("{id}")]
    public IActionResult GetOrgName([FromRoute] int id)
    {
        var result = _organizationService.OrganizationNameById(id);
        return Ok(result);
    }
}
