using Api.Base;
using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ClientController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Client APIs
    //-------------------------------
    [HttpPost("add-client")]
    public async Task<IActionResult> AddClient([FromBody] AddClientRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-client/{id}")]
    public IActionResult GetClient([FromRoute] int id)
    {
        var response = mediator.HandleById<ClientResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-client")]
    public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-client")]
    public IActionResult GetAll(ClientAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-client")]
    public async Task<IActionResult> DeleteClient([FromBody] DeleteClientRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region ClientAccount APIs
    //-------------------------------
    [HttpPost("add-client-account")]
    public async Task<IActionResult> AddClientAccount([FromBody] AddClientAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-client-account/{id}")]
    public IActionResult GetClientAccount([FromRoute] int id)
    {
        var response = mediator.HandleById<ClientAccountResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-client-account")]
    public async Task<IActionResult> UpdateClientAccount([FromBody] UpdateClientAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-client-account")]
    public IActionResult GetAll(ClientAccountAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-client-account")]
    public async Task<IActionResult> DeleteClientAccount([FromBody] DeleteClientAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region ClientProperty APIs
    //-------------------------------
    [HttpPost("add-client-property")]
    public async Task<IActionResult> AddClientProperty([FromBody] AddClientPropertyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-client-property/{id}")]
    public IActionResult GetClientProperty([FromRoute] int id)
    {
        var response = mediator.HandleById<ClientPropertyResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-client-property")]
    public async Task<IActionResult> UpdateClientProperty([FromBody] UpdateClientPropertyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-client-property")]
    public IActionResult GetAll(ClientPropertyAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-client-property")]
    public async Task<IActionResult> DeleteClientProperty([FromBody] DeleteClientPropertyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion    

    //-------------------------------
    #region ClientService APIs
    //-------------------------------
    [HttpPost("add-client-service")]
    public async Task<IActionResult> AddClientService([FromBody] AddClientServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-client-service/{id}")]
    public IActionResult GetClientService([FromRoute] int id)
    {
        var response = mediator.HandleById<ClientServiceResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-client-service")]
    public async Task<IActionResult> UpdateClientService([FromBody] UpdateClientServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-client-service")]
    public IActionResult GetAll(ClientServiceAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-client-service")]
    public async Task<IActionResult> DeleteClientService([FromBody] DeleteClientServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
