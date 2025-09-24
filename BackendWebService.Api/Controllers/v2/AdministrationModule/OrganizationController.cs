using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Services;
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class OrganizationController(IMediator mediator) : AppControllerBase
{
    //-------------------------------
    #region Consumer APIs
    //-------------------------------
    [HttpPost("add-organization")]
    public async Task<IActionResult> AddOrganization([FromBody] AddOrganizationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-organization/{id}")]
    public async Task<IActionResult> GetOrganization([FromRoute] int id)
    {
        var response = mediator.HandleById<OrganizationResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-organization")]
    public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-organization")]
    public IActionResult GetAll(OrganizationAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-organization")]
    public async Task<IActionResult> DeleteOrganization([FromBody] DeleteOrganizationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Address APIs
    //-------------------------------

    [HttpPost("add-address")]
    public async Task<IActionResult> AddAddress([FromBody] AddAddressRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-address/{id}")]
    public async Task<IActionResult> GetAddress([FromRoute] int id)
    {
        var response = mediator.HandleById<AddressResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-address")]
    public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-address")]
    public IActionResult GetAll(AddressAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-address")]
    public async Task<IActionResult> DeleteAddress([FromBody] DeleteAddressRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Administrator APIs
    //-------------------------------
    [HttpPost("add-administrator")]
    public async Task<IActionResult> AddAdministrator([FromBody] AddAdministratorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-administrator/{id}")]
    public async Task<IActionResult> GetAdministrator([FromRoute] int id)
    {
        var response = mediator.HandleById<AdministratorResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-administrator")]
    public async Task<IActionResult> UpdateAdministrator([FromBody] UpdateAdministratorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-administrator")]
    public IActionResult GetAll(AdministratorAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-administrator")]
    public async Task<IActionResult> DeleteAdministrator([FromBody] DeleteAdministratorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Contact APIs
    //-------------------------------
    [HttpPost("add-contact")]
    public async Task<IActionResult> AddContact([FromBody] AddContactRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-contact/{id}")]
    public async Task<IActionResult> GetContact([FromRoute] int id)
    {
        var response = mediator.HandleById<ContactResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-contact")]
    public async Task<IActionResult> UpdateContact([FromBody] UpdateContactRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-contact")]
    public IActionResult GetAll(ContactAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-contact")]
    public async Task<IActionResult> DeleteContact([FromBody] DeleteContactRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Department APIs
    //-------------------------------
    [HttpPost("add-department")]
    public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-department/{id}")]
    public async Task<IActionResult> GetDepartment([FromRoute] int id)
    {
        var response = mediator.HandleById<DepartmentResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-department")]
    public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-department")]
    public IActionResult GetAll(DepartmentAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-department")]
    public async Task<IActionResult> DeleteDepartment([FromBody] DeleteDepartmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region GoogleConfig APIs
    //-------------------------------
    [HttpPost("add-google-config")]
    public async Task<IActionResult> AddGoogleConfig([FromBody] AddGoogleConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-google-config/{id}")]
    public async Task<IActionResult> GetGoogleConfig([FromRoute] int id)
    {
        var response = mediator.HandleById<GoogleConfigResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-google-config")]
    public async Task<IActionResult> UpdateGoogleConfig([FromBody] UpdateGoogleConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-google-config")]
    public IActionResult GetAll(GoogleConfigAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-google-config")]
    public async Task<IActionResult> DeleteGoogleConfig([FromBody] DeleteGoogleConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region LDAPConfig APIs
    //-------------------------------
    [HttpPost("add-ldap-config")]
    public async Task<IActionResult> AddLDAPConfig([FromBody] AddLDAPConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-ldap-config/{id}")]
    public async Task<IActionResult> GetLDAPConfig([FromRoute] int id)
    {
        var response = mediator.HandleById<LDAPConfigResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-ldap-config")]
    public async Task<IActionResult> UpdateLDAPConfig([FromBody] UpdateLDAPConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-ldap-config")]
    public IActionResult GetAll(LDAPConfigAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-ldap-config")]
    public async Task<IActionResult> DeleteLDAPConfig([FromBody] DeleteLDAPConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region MicrosoftConfig APIs
    //-------------------------------
    [HttpPost("add-microsoft-config")]
    public async Task<IActionResult> AddMicrosoftConfig([FromBody] AddMicrosoftConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-microsoft-config/{id}")]
    public async Task<IActionResult> GetMicrosoftConfig([FromRoute] int id)
    {
        var response = mediator.HandleById<MicrosoftConfigResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-microsoft-config")]
    public async Task<IActionResult> UpdateMicrosoftConfig([FromBody] UpdateMicrosoftConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-microsoft-config")]
    public IActionResult GetAll(MicrosoftConfigAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-microsoft-config")]
    public async Task<IActionResult> DeleteMicrosoftConfig([FromBody] DeleteMicrosoftConfigRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
