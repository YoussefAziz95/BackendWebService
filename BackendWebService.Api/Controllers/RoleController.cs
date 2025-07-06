using Application.Contracts.AppManager;
using Application.Features;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RoleController : ControllerBase
{
    private readonly IAppRoleManager _roleManager;

    public RoleController(IAppRoleManager roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Role role)
    {
        var result = await _roleManager.CreateAsync(role);
        if (result.Succeeded)
            return Ok(role);

        return BadRequest(result.Errors);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
            return NotFound();

        var result = await _roleManager.DeleteAsync(role);
        if (result.Succeeded)
            return Ok(role.Id);

        return BadRequest(result.Errors);
    }

    [HttpGet("find-by-id/{id}")]
    public async Task<IActionResult> FindById(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
            return NotFound();

        return Ok(role);
    }

    [HttpGet("find-by-name/{name}")]
    public async Task<IActionResult> FindByName(string name)
    {
        var role = await _roleManager.FindByNameAsync(name);
        if (role == null)
            return NotFound();

        return Ok(role);
    }

    [HttpPost("add-claim")]
    public async Task<IActionResult> AddClaim([FromBody] RoleClaimRequest request)
    {
        var role = await _roleManager.FindByIdAsync(request.RoleId);
        if (role == null)
            return NotFound();

        var result = await _roleManager.AddClaimAsync(role, new Claim(request.ClaimType, request.ClaimValue));
        if (result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }

    [HttpPost("remove-claim")]
    public async Task<IActionResult> RemoveClaim([FromBody] RoleClaimRequest request)
    {
        var role = await _roleManager.FindByIdAsync(request.RoleId);
        if (role == null)
            return NotFound();

        var result = await _roleManager.RemoveClaimAsync(role, new Claim(request.ClaimType, request.ClaimValue));
        if (result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }

    [HttpGet("get-claims/{id}")]
    public async Task<IActionResult> GetClaims(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
            return NotFound();

        var claims = await _roleManager.GetClaimsAsync(role);
        return Ok(claims);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] Role role)
    {
        var result = await _roleManager.UpdateAsync(role);
        if (result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }

    [HttpGet("exists/{name}")]
    public async Task<IActionResult> RoleExists(string name)
    {
        var exists = await _roleManager.RoleExistsAsync(name);
        return Ok(new { exists });
    }
}


